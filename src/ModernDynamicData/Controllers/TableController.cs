using Microsoft.AspNet.Mvc;
using ModernDynamicData.Providers;
using ModernDynamicData.ViewModels.Table;
using System.Linq;

namespace ModernDynamicData.Controllers
{
    public class TableController : DynamicDataControllerBase
    {
        public TableController(IDataModelDescriptorProvider dataModelDescriptorProvider)
            : base(dataModelDescriptorProvider)
        { }

        public IActionResult View(string dataModel, string table)
        {
            var dataModelDescriptor = DataModelDescriptorProvider.GetDataModelDescriptorByName(dataModel);
            var tableDescriptor = dataModelDescriptor.Tables.FirstOrDefault(t => t.Name == table);
            var viewModel = CreateViewModel<ViewViewModel>(vm => vm.Table = tableDescriptor);
            return View(viewModel);
        }
        public IActionResult Edit(string dataModel, string table) => Empty();
        public IActionResult AddItem(string dataModel, string table) => Empty();
    }
}