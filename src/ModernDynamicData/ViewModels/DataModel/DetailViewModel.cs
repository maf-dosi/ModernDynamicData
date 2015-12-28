using ModernDynamicData.Abstractions.DataProviders;

namespace ModernDynamicData.ViewModels.DataModel
{
    public class DetailViewModel : ViewModelBase
    {
        public override string Title => DataModel.DataModelName;
        public DataModelDescriptor DataModel { get; set; }
    }
}