using System;
using ModernDynamicData.Host.Web.Providers;

namespace ModernDynamicData.Host.Web.DependencyInjection
{
    public static class ServiceProviderExtensions
    {
        public static IDataModelDescriptorProvider GetDataModelDescriptorProvider(this IServiceProvider serviceProvider)
        {
            Guard.NotNull(serviceProvider, nameof(serviceProvider));

            return (IDataModelDescriptorProvider)serviceProvider.GetService(typeof(IDataModelDescriptorProvider));
        }
    }
}
