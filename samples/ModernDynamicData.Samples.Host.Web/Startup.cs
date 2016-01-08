using System;
using Microsoft.AspNet.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Framework.DependencyInjection;
using ModernDynamicData.Samples.Host.Web.DataProvider;

namespace ModernDynamicData.Samples.Host.Web
{
    public class Startup
    {
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDynamicData();
        }

        public void Configure(IApplicationBuilder app, IServiceProvider serviceProvider)
        {
            // Add the platform handler to the request pipeline.
            app.UseIISPlatformHandler();

            app.RunDynamicData(serviceProvider, new FakeDataModelDescriptor("Test"),
                new FakeDataModelDescriptor("Test2"));
        }
    }
}