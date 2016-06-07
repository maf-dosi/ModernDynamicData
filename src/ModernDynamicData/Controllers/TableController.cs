using Microsoft.AspNetCore.Mvc;
using ModernDynamicData.Providers;

namespace ModernDynamicData.Controllers
{
    public class TableController : DynamicDataControllerBase
    {
        public TableController(IDataModelDescriptorProvider dataModelDescriptorProvider)
            : base(dataModelDescriptorProvider)
        { }

        public IActionResult View(string dataModel, string table) => Empty();
        public IActionResult Edit(string dataModel, string table) => Empty();
        public IActionResult AddItem(string dataModel, string table) => Empty();
    }
}