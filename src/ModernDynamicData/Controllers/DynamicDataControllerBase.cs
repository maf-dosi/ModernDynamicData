using System;
using System.Reflection;
using System.Text;
using Microsoft.AspNet.Antiforgery;
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

        protected IActionResult Empty()
        {
            var contentStringBuilder = new StringBuilder();
            foreach (var token in ActionContext.RouteData.DataTokens)
            {
                contentStringBuilder.AppendFormat("{0}:{1};", token.Key, token.Value);
            }
            if (contentStringBuilder.Length > 0)
            {
                contentStringBuilder.Remove(contentStringBuilder.Length - 1, 1);
            }
            return Content(contentStringBuilder.ToString());
        }

        protected TViewModel CreateViewModel<TViewModel>()
            where TViewModel : ViewModelBase, new()
        {
            var viewModel = CreateViewModel<TViewModel>(_ => { });
            return viewModel;
        }
        protected TViewModel CreateViewModel<TViewModel>(Action<TViewModel> setProperties)
            where TViewModel : ViewModelBase, new()
        {
            var viewModel = new TViewModel();
            InitializeViewModel(viewModel);
            setProperties(viewModel);
            return viewModel;
        }
        protected void InitializeViewModel(ViewModelBase viewModel)
        {
            viewModel.Version = typeof (DynamicDataControllerBase).GetTypeInfo().Assembly.GetName().Version.ToString();
        }
    }
}