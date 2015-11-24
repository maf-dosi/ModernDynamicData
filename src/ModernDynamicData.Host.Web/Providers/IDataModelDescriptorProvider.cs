using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
