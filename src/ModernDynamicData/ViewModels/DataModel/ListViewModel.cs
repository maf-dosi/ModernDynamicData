using System.Collections.Generic;
using ModernDynamicData.Abstractions.DataProviders;

namespace ModernDynamicData.ViewModels.DataModel
{
    public class ListViewModel : ViewModelBase
    {
        public override string Title => "Data models list";
        public IEnumerable<DataModelDescriptor> DataModels { get; set; }
    }
}