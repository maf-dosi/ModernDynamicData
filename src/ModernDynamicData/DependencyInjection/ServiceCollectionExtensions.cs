using System.Reflection;
using Microsoft.AspNet.FileProviders;
using Microsoft.AspNet.Mvc.Razor;
using ModernDynamicData;
using ModernDynamicData.Infrastructure;
using ModernDynamicData.Providers;
using Microsoft.Extensions.DependencyInjection;

// ReSharper disable once CheckNamespace

namespace Microsoft.Framework.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDynamicData(this IServiceCollection services, IFileProvider fileProvider = null)
        {
            services.AddMvc();

            services.AddSingleton<IDataModelDescriptorProvider, DataModelDescriptorProvider>();

            services.Configure<RazorViewEngineOptions>(options =>
                options.FileProvider = new ListOfFileProvider(
                    fileProvider ?? options.FileProvider,
                    new EmbeddedFileProvider(typeof (Guard).GetTypeInfo().Assembly, nameof(ModernDynamicData))
                    )
                );
        }
    }
}