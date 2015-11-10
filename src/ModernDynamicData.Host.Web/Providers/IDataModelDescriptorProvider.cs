using System.Collections.Generic;
using ModernDynamicData.Abstractions.DataProviders;

namespace ModernDynamicData.Host.Web.Providers
{
    public interface IDataModelDescriptorProvider
    {
        int GetNumberOfDataModelDescriptors();
        IEnumerable<DataModelDescriptor> GetAllDataModelDescriptors();
        DataModelDescriptor GetDataModelDescriptorByName(string name);
        void AddDataModelDescriptor(DataModelDescriptor dataModelDescriptor);
    }
}
