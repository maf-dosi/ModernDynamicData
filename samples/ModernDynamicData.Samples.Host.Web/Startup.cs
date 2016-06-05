using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ModernDynamicData.Providers.Fake;

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
            app.RunDynamicData(serviceProvider, new FakeDataModelDescriptor("Test"),
                new FakeDataModelDescriptor("Test2"));
        }
    }
}