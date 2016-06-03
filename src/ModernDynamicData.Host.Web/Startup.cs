using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using ModernDynamicData.Providers.Fake;

namespace ModernDynamicData.Host.Web
{
    public class Startup
    {
        private readonly string _applicationBasePath;
        private readonly string _wwwrootApplicationBasePath;
        public Startup(IHostingEnvironment env)
        {
            _applicationBasePath = Path.Combine(env.ContentRootPath, "..", nameof(ModernDynamicData));
            _wwwrootApplicationBasePath = Path.Combine(_applicationBasePath, "wwwroot");

            env.WebRootFileProvider = new PhysicalFileProvider(_wwwrootApplicationBasePath);
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDynamicData(new PhysicalFileProvider(_applicationBasePath));
        }

        // Configure is called after ConfigureServices is called.
        public void Configure(IApplicationBuilder app, IServiceProvider serviceProvider)
        {
            // Add the platform handler to the request pipeline.
            //app.UseIISPlatformHandler(); // TODO

            app.RunDynamicData(serviceProvider, new FakeDataModelDescriptor("Test"),
                new FakeDataModelDescriptor("Test2"));
        }
    }
}