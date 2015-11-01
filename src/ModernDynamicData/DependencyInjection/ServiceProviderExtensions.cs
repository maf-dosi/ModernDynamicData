using ModernDynamicData;
using ModernDynamicData.Providers;

// ReSharper disable once CheckNamespace

namespace System
{
    public static class ServiceProviderExtensions
    {
        public static IDataModelDescriptorProvider GetDataModelDescriptorProvider(this IServiceProvider serviceProvider)
        {
            Guard.NotNull(serviceProvider, nameof(serviceProvider));

            return (IDataModelDescriptorProvider) serviceProvider.GetService(typeof (IDataModelDescriptorProvider));
        }
    }
}