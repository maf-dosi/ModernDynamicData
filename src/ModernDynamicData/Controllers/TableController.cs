using Microsoft.AspNet.Mvc;
using ModernDynamicData.Providers;

namespace ModernDynamicData.Controllers
{
    public class TableController : DynamicDataControllerBase
    {
        public TableController(IDataModelDescriptorProvider dataModelDescriptorProvider)
            : base(dataModelDescriptorProvider)
        { }

        public IActionResult Detail(string dataModel, string table) => Empty();
    }
}