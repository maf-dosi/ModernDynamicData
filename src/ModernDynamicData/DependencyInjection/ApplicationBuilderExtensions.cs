using System;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.StaticFiles;
using ModernDynamicData.Abstractions.DataProviders;
using Microsoft.AspNetCore.Hosting;
using ModernDynamicData.Infrastructure;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Routing;
using ModernDynamicData;

// ReSharper disable once CheckNamespace
namespace Microsoft.AspNetCore.Builder
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder RunDynamicData(this IApplicationBuilder applicationBuilder, IServiceProvider serviceProvider, params DataModelDescriptor[] dataModelDescriptors)
        {
            var numberOfDataModelDescriptors = dataModelDescriptors.Length;
            if (numberOfDataModelDescriptors == 0)
            {
                throw new InvalidOperationException("You should provide at least one DataModelProvider");
            }
            var dataModelDescriptorProvider = serviceProvider.GetDataModelDescriptorProvider();
            foreach (var dataModelDescriptor in dataModelDescriptors)
            {
                dataModelDescriptorProvider.AddDataModelDescriptor(dataModelDescriptor);
            }
            var dataModelPrefix = "{dataModel}/";
            var dataModelDefault = "";
            if (numberOfDataModelDescriptors == 1)
            {
                dataModelPrefix = "";
                dataModelDefault = dataModelDescriptors.Single().DataModelName;
            }
            var hostingEnvironment = (IHostingEnvironment)serviceProvider.GetService(typeof(IHostingEnvironment));
            applicationBuilder.UseStaticFiles(new StaticFileOptions
            {
                FileProvider =
                new ListOfFileProvider(
                    hostingEnvironment.WebRootFileProvider,
                    new EmbeddedFileProvider(typeof(Guard).GetTypeInfo().Assembly, nameof(ModernDynamicData) + ".wwwroot")
                )
            });

            applicationBuilder.UseMvc(routes => ConfigureRoutes(routes, dataModelPrefix, dataModelDefault, numberOfDataModelDescriptors));

            return applicationBuilder;
        }

        private static void ConfigureRoutes(IRouteBuilder routeBuilder, string dataModelPrefix, string dataModelDefault, int numberOfDataModelDescriptors)
        {
            routeBuilder.MapRoute(Constants.Routes.Table, dataModelPrefix + "{action}/{table}", new { controller = "Table", dataModel = dataModelDefault });

            if (numberOfDataModelDescriptors == 1)
            {
                routeBuilder.MapRoute("context", "", new { controller = "DataModel", action = "Detail", dataModel = dataModelDefault });
            }
            else
            {
                routeBuilder.MapRoute(Constants.Routes.ContextDetail, "{dataModel}", new { controller = "DataModel", action = "Detail" });
                routeBuilder.MapRoute("context", "", new { controller = "DataModel", action = "List" });
            }
        }
    }
}