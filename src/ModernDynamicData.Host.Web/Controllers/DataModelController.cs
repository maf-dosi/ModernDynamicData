﻿using Microsoft.AspNet.Mvc;
using ModernDynamicData.Host.Web.Providers;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ModernDynamicData.Host.Web.Controllers
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
