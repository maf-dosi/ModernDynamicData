using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using ModernDynamicData.Host.Web.Providers;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ModernDynamicData.Host.Web.Controllers
{
    public class DynamicDataControllerBase : Controller
    {
        protected DynamicDataControllerBase(IDataModelDescriptorProvider dataModelDescriptorProvider)
        {
            DataModelDescriptorProvider = dataModelDescriptorProvider;
        }

        protected IDataModelDescriptorProvider DataModelDescriptorProvider { get; }

        protected IActionResult Empty() => new EmptyResult();
    }
}
