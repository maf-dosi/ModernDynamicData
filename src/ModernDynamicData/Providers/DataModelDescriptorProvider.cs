using System;
using System.Collections.Generic;
using ModernDynamicData.Abstractions.DataProviders;

namespace ModernDynamicData.Providers
{
    public class DataModelDescriptorProvider: IDataModelDescriptorProvider
    {
        private readonly Dictionary<string, DataModelDescriptor> _dataModelDescriptors = new Dictionary<string, DataModelDescriptor>(StringComparer.Ordinal);
        public int GetNumberOfDataModelDescriptors() => _dataModelDescriptors.Count;

        public IEnumerable<DataModelDescriptor> GetAllDataModelDescriptors() => _dataModelDescriptors.Values;

        public DataModelDescriptor GetDataModelDescriptorByName(string name)
        {
            Guard.NotEmpty(name, nameof(name));

            if (_dataModelDescriptors.ContainsKey(name))
            {
                return _dataModelDescriptors[name];
            }
            return null;
        }

        public void AddDataModelDescriptor(DataModelDescriptor dataModelDescriptor)
        {
            Guard.NotNull(dataModelDescriptor, nameof(dataModelDescriptor));

            var dataModelName = dataModelDescriptor.DataModelName;
            if (_dataModelDescriptors.ContainsKey(dataModelName))
            {
                _dataModelDescriptors.Add(dataModelName, dataModelDescriptor);
            }
            else
            {
                throw new ArgumentException($"There is already a dataModel (of type '{_dataModelDescriptors[dataModelName].DataModelName}' for the name '{dataModelName}'");
            }
        }
    }
}