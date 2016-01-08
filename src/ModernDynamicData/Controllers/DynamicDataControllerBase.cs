using System;
using System.Reflection;
using Microsoft.AspNet.Mvc;
using ModernDynamicData.Providers;
using ModernDynamicData.ViewModels;

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

        protected TViewModel CreateViewModel<TViewModel>()
            where TViewModel : ViewModelBase, new()
        {
            var viewModel = new TViewModel();
            viewModel.Version = typeof (DynamicDataControllerBase).GetTypeInfo().Assembly.GetName().Version.ToString();
            return viewModel;
        }
    }
}