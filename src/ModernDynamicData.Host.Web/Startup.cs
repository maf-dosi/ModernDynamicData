using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using ModernDynamicData.Providers.Fake;

namespace ModernDynamicData.Host.Web
{
    public class Startup
    {
        private readonly string _applicationBasePath;

        public Startup(IHostingEnvironment env)
        {
            _applicationBasePath = Path.Combine(env.ContentRootPath, "..", nameof(ModernDynamicData));
            var wwwrootApplicationBasePath = Path.Combine(_applicationBasePath, "wwwroot");

            env.WebRootFileProvider = new PhysicalFileProvider(wwwrootApplicationBasePath);
        }

        // This method gets called by the runtime.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDynamicData(new PhysicalFileProvider(_applicationBasePath));
        }

        // Configure is called after ConfigureServices is called.
        public void Configure(IApplicationBuilder app, IServiceProvider serviceProvider)
        {
            app.RunDynamicData(serviceProvider, new FakeDataModelDescriptor("Test"),
                new FakeDataModelDescriptor("Test2"));
        }
    }
}