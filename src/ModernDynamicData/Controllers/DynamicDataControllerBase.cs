using System;
using Microsoft.AspNet.Mvc;
using ModernDynamicData.Providers;

namespace ModernDynamicData.Controllers
{
    public abstract class DynamicDataControllerBase : Controller
    {
        protected DynamicDataControllerBase(IDataModelDescriptorProvider dataModelDescriptorProvider)
        {
            DataModelDescriptorProvider = dataModelDescriptorProvider;
        }

        protected IDataModelDescriptorProvider DataModelDescriptorProvider { get; }

        protected IActionResult Empty() => new EmptyResult();
    }
}