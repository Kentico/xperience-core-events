using Kentico.Content.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Xperience.Core.Events
{
    public class EventRegistrationFormWidgetViewComponent : ViewComponent
    {
        public const string IDENTIFIER = "Xperience.Core.Events.EventRegistrationForm";
        private readonly IPageUrlRetriever pageUrlRetriever;

        public EventRegistrationFormWidgetViewComponent(IPageUrlRetriever pageUrlRetriever)
        {
            this.pageUrlRetriever = pageUrlRetriever;
        }

        public IViewComponentResult Invoke(ComponentViewModel<EventRegistrationFormWidgetProperties> viewModel)
        {
            if (viewModel is null)
            {
                throw new ArgumentNullException(nameof(viewModel));
            }

            string data = string.Empty;
            if(viewModel.Properties.SubmitAction.Equals("redirect"))
            {
                if(viewModel.Properties.RedirectTo.Count() > 0)
                {
                    data = pageUrlRetriever.Retrieve(viewModel.Properties.RedirectTo.FirstOrDefault().NodeAliasPath).AbsoluteUrl;
                }
            }
            else
            {
                data = viewModel.Properties.Text;
            }

            var registrationModel = new RegistrationModel()
            {
                SubmitAction = viewModel.Properties.SubmitAction,
                ActionRelatedData = data
            };

            return View("~/Components/Widgets/EventRegistrationFormWidget/_EventRegistrationForm.cshtml", registrationModel);
        }
    }
}