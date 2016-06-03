using System.Reflection;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Mvc.Razor;
using ModernDynamicData;
using ModernDynamicData.Infrastructure;
using ModernDynamicData.Providers;

// ReSharper disable once CheckNamespace

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDynamicData(this IServiceCollection services, IFileProvider fileProvider = null)
        {
            services.AddMvc();

            services.AddSingleton<IDataModelDescriptorProvider, DataModelDescriptorProvider>();

            services.Configure<RazorViewEngineOptions>(options =>
            {
                if (fileProvider != null)
                {
                    options.FileProviders.Add(fileProvider);
                }
                options.FileProviders.Add(new EmbeddedFileProvider(typeof(Guard).GetTypeInfo().Assembly,
                    nameof(ModernDynamicData)));
            });
        }
    }
}