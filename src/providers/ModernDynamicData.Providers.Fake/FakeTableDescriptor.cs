using System.Collections.Generic;
using System.Collections.ObjectModel;
using ModernDynamicData.Abstractions.DataProviders;

namespace ModernDynamicData.Providers.Fake
{
    public class FakeTableDescriptor : TableDescriptor
    {
        public FakeTableDescriptor(DataModelDescriptor model, string name) : base(model)
        {
            Name = name;
            var columns = new List<ColumnDescriptor>();
            for (var i = 0; i < 3; i++)
            {
                columns.Add(new FakeColumnDescriptor(this, "Column_" + i));
            }
            Columns = new ReadOnlyCollection<ColumnDescriptor>(columns);
        }

        public override ReadOnlyCollection<ColumnDescriptor> Columns { get; }
    }
}