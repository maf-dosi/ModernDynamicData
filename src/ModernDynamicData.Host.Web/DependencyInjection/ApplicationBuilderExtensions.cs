﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using ModernDynamicData.Abstractions.DataProviders;

namespace ModernDynamicData.Host.Web.DependencyInjection
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

            applicationBuilder.UseMvc(routes =>
            {
                routes.MapRoute("tableList", dataModelPrefix + "{table}", new { controller = "Table", action = "Detail", dataModel = dataModelDefault });
                if (numberOfDataModelDescriptors == 1)
                {
                    routes.MapRoute("context", "", new { controller = "DataModel", action = "Detail", dataModel = dataModelDefault });
                }
                else
                {
                    routes.MapRoute("contextDetail", "{dataModel}", new { controller = "DataModel", action = "Detail" });
                    routes.MapRoute("context", "", new { controller = "DataModel", action = "List" });
                }
            }
                );

            return applicationBuilder;
        }
    }
}
