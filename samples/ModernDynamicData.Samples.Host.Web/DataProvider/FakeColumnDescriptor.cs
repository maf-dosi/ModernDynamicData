using ModernDynamicData.Abstractions.DataProviders;

namespace ModernDynamicData.Samples.Host.Web.DataProvider
{
    public class FakeColumnDescriptor : ColumnDescriptor
    {
        public FakeColumnDescriptor(TableDescriptor table, string name) : base(table)
        {
            Name = name;
        }
    }
}