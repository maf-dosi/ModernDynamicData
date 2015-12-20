using System;
using System.Linq;
using System.Reflection;
using Microsoft.AspNet.StaticFiles;
using ModernDynamicData.Abstractions.DataProviders;
using Microsoft.AspNet.Hosting;
using ModernDynamicData.Infrastructure;
using Microsoft.AspNet.FileProviders;
using ModernDynamicData;

// ReSharper disable once CheckNamespace
namespace Microsoft.AspNet.Builder
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
            var hostingEnvironment = serviceProvider.GetService(typeof(IHostingEnvironment)) as IHostingEnvironment;
            applicationBuilder.UseStaticFiles(new StaticFileOptions
            {
                FileProvider =
                new ListOfFileProvider(
                hostingEnvironment.WebRootFileProvider,
                new EmbeddedFileProvider(typeof(Guard).GetTypeInfo().Assembly, nameof(ModernDynamicData) + "wwwroot")
                )
            });

            applicationBuilder.UseMvc(routes =>
            {
                routes.MapRoute("tableList", dataModelPrefix + "{table}", new {controller = "Table", action = "Detail", dataModel = dataModelDefault});
                if (numberOfDataModelDescriptors == 1)
                {
                    routes.MapRoute("context", "", new {controller = "DataModel", action = "Detail", dataModel = dataModelDefault});
                }
                else
                {
                    routes.MapRoute("contextDetail", "{dataModel}", new {controller = "DataModel", action = "Detail"});
                    routes.MapRoute("context", "", new {controller = "DataModel", action = "List"});
                }
            }
                );

            return applicationBuilder;
        }
    }
}