using ModernDynamicData.Abstractions.DataProviders;

namespace ModernDynamicData.Providers.Fake
{
    public class FakeColumnDescriptor : ColumnDescriptor
    {
        public FakeColumnDescriptor(TableDescriptor table, string name) : base(table)
        {
            Name = name;
        }
    }
}