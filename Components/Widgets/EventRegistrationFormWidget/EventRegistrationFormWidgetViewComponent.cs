using Kentico.PageBuilder.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Xperience.Core.Events
{
    public class EventRegistrationFormWidgetViewComponent : ViewComponent
    {
        public const string IDENTIFIER = "Xperience.Core.Events.EventRegistrationForm";

        public EventRegistrationFormWidgetViewComponent()
        {

        }

        public IViewComponentResult Invoke(ComponentViewModel viewModel)
        {
            if (viewModel is null)
            {
                throw new ArgumentNullException(nameof(viewModel));
            }

            return View("~/Components/Widgets/EventRegistrationFormWidget/_EventRegistrationForm.cshtml", new RegistrationModel());
        }
    }
}