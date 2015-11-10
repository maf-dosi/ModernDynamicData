using System;
using System.Linq;
using Microsoft.AspNet.Mvc;
using ModernDynamicData.Host.Web.Providers;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ModernDynamicData.Host.Web.Controllers
{
    public class TableController : DynamicDataControllerBase
    {
        public TableController(IDataModelDescriptorProvider dataModelDescriptorProvider)
            : base(dataModelDescriptorProvider)
        { }

        public IActionResult Detail(string dataModel, string table)
        {
            if (dataModel == null || table == null)
                throw new ArgumentNullException(nameof(table));

            var _dataModel = DataModelDescriptorProvider.GetDataModelDescriptorByName(dataModel);

            var _table = _dataModel.Tables.Single(c => c.Name == table);

            return View();
        } 
    }
}
