using Microsoft.AspNet.Mvc;
using ModernDynamicData.Providers;

namespace ModernDynamicData.Controllers
{
    public class DataModelController : DynamicDataControllerBase
    {
        public DataModelController(IDataModelDescriptorProvider dataModelDescriptorProvider)
            : base(dataModelDescriptorProvider)
        { }

        public IActionResult List() => View(DataModelDescriptorProvider.GetAllDataModelDescriptors());

        public IActionResult Detail(string dataModel)
        {
            var dataModelDescriptor = DataModelDescriptorProvider.GetDataModelDescriptorByName(dataModel);
            return View(dataModelDescriptor);
        }
    }
}