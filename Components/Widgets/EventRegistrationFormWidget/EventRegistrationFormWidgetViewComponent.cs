using CMS.ContactManagement;
using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.Xperience;
using CMS.Helpers;
using Events;
using Kentico.Content.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public IViewComponentResult Invoke(ComponentViewModel viewModel)
        {
            if (viewModel is null)
            {
                throw new ArgumentNullException(nameof(viewModel));
            }

            return View("~/Components/Widgets/EventCalendarWidget/_EventCalendar.cshtml");
        }

    }
}