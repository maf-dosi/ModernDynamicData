using System;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.FileProviders;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.DependencyInjection;
using ModernDynamicData.Samples.Host.Web.DataProvider;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNet.Mvc.Razor;
using ModernDynamicData.Infrastructure;

namespace ModernDynamicData.Samples.Host.Web
{
    public class Startup
    {
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDynamicData(new PhysicalFileProvider(
                    @"C:\Users\mgrosperrin\Documents\GitHub\maf-dosi\ModernDynamicData\src\ModernDynamicData"));
        }

        public void Configure(IApplicationBuilder app, IServiceProvider serviceProvider, IHostingEnvironment hostingEnvironment)
        {
            // Add the platform handler to the request pipeline.
            app.UseIISPlatformHandler();

            hostingEnvironment.WebRootFileProvider = new PhysicalFileProvider(
                @"C:\Users\mgrosperrin\Documents\GitHub\maf-dosi\ModernDynamicData\src\ModernDynamicData\wwwroot");

            app.RunDynamicData(serviceProvider, new FakeDataModelDescriptor("Test"),
                new FakeDataModelDescriptor("Test2"));
        }
    }
}