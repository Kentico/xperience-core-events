
using CMS;
using Kentico.PageBuilder.Web.Mvc;
using Xperience.Core.Events;

[assembly: AssemblyDiscoverable]
[assembly: RegisterWidget(EventCalendarWidgetViewComponent.IDENTIFIER,
    typeof(EventCalendarWidgetViewComponent),
    "Event calendar",
    typeof(EventCalendarWidgetProperties),
    Description = "Displays a calendar  including events from the selected path in the content tree",
    IconClass = "icon-calendar-number")]
[assembly: RegisterWidget(EventRegistrationFormWidgetViewComponent.IDENTIFIER,
    typeof(EventRegistrationFormWidgetViewComponent),
    "Event registration",
    null,
    Description = "Allows visitors to register for events",
    IconClass = "icon-personalisation-variants")]