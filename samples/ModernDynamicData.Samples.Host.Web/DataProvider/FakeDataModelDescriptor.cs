using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ModernDynamicData.Abstractions.DataProviders;

namespace ModernDynamicData.Samples.Host.Web.DataProvider
{
    public class FakeDataModelDescriptor : DataModelDescriptor
    {
        public FakeDataModelDescriptor(string name)
        {
            DataModelName = name;
            var tables = new List<TableDescriptor>();
            for (var i = 0; i < 5; i++)
            {
                tables.Add(new FakeTableDescriptor(this, "Table_" + i));
            }
            Tables = new ReadOnlyCollection<TableDescriptor>(tables);
        }

        public override ReadOnlyCollection<TableDescriptor> Tables { get; }

        public override object CreateContext()
        {
            throw new NotImplementedException();
        }
    }
}