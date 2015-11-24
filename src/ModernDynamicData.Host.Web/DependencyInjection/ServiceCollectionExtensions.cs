using System.Reflection;
using Microsoft.AspNet.FileProviders;
using Microsoft.AspNet.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using ModernDynamicData.Host.Web.Infrastructure;
using ModernDynamicData.Host.Web.Providers;

namespace ModernDynamicData.Host.Web.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDynamicData(this IServiceCollection services)
        {
            services.AddMvc();

            services.AddSingleton<IDataModelDescriptorProvider, DataModelDescriptorProvider>();

            services.Configure<RazorViewEngineOptions>(options =>
                options.FileProvider = new ListOfFileProvider(
                    options.FileProvider,
                    new EmbeddedFileProvider(typeof(Guard).GetTypeInfo().Assembly, nameof(ModernDynamicData))
                    )
                );
        }
    }
}
