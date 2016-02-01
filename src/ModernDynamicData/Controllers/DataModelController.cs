using Microsoft.AspNet.Mvc;
using ModernDynamicData.Providers;
using ModernDynamicData.ViewModels.DataModel;

namespace ModernDynamicData.Controllers
{
    public class DataModelController : DynamicDataControllerBase
    {
        public DataModelController(IDataModelDescriptorProvider dataModelDescriptorProvider)
            : base(dataModelDescriptorProvider)
        { }

        public IActionResult List()
        {
            var dataModels = DataModelDescriptorProvider.GetAllDataModelDescriptors();
            var viewModel = CreateViewModel<ListViewModel>(vm => vm.DataModels = dataModels);
            return View(viewModel);
        }

        public IActionResult Detail(string dataModel)
        {
            var dataModelDescriptor = DataModelDescriptorProvider.GetDataModelDescriptorByName(dataModel);

            var viewModel = CreateViewModel<DetailViewModel>(vm => vm.DataModel = dataModelDescriptor);
            return View(viewModel);
        }
    }
}