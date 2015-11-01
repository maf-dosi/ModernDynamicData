using Microsoft.AspNet.Mvc;
using ModernDynamicData.Providers;

namespace ModernDynamicData.Controllers
{
    public class DataModelController : DynamicDataControllerBase
    {
        public DataModelController(IDataModelDescriptorProvider dataModelDescriptorProvider)
            : base(dataModelDescriptorProvider)
        { }

        public IActionResult List() => Empty();

        public IActionResult Detail(string dataModel) => Empty();
    }
}