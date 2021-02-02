using CMS.DocumentEngine.Types.Xperience;
using CMS.Helpers;
using CMS.Newsletters;
using Events;
using Kentico.Content.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Xperience.Core.Events
{
    public class EventRegistrationFormWidgetController : Controller
    {
        private readonly IPageDataContextRetriever pageDataContext;
        private readonly IContactProvider contactProvider;


        public EventRegistrationFormWidgetController(IPageDataContextRetriever pageDataContext, IContactProvider contactProvider)
        {
            this.pageDataContext = pageDataContext;
            this.contactProvider = contactProvider;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegistrationModel model)
        {
            if (!ValidationHelper.IsEmail(model.Email))
            {
                ModelState.AddModelError("Email", "Invalid email.");

                return PartialView("~/Components/Widgets/EventRegistrationFormWidget/_EventRegistrationForm.cshtml", model);
            }

            string result = "";
            var page = pageDataContext.Retrieve<Event>().Page;
            var contact = contactProvider.GetContactForSubscribing(model.Email);
 
            if(contact != null)
            {
                // Update contact info
                contact.ContactFirstName = model.FirstName;
                contact.ContactLastName = model.LastName;
                contact.Update();

                // Check if contact is already registered
                var existingAttendee = EventAttendeeInfoProvider.ProviderObject.Get()
                    .WhereEquals("ContactID", contact.ContactID)
                    .WhereEquals("NodeID", page.NodeID)
                    .TopN(1)
                    .FirstOrDefault();

                if (existingAttendee != null)
                {
                    result = "You are already registered for this event!";
                }
                else
                {
                    // Successful registration
                    EventAttendeeInfoProvider.ProviderObject.Set(new EventAttendeeInfo() {
                        ContactID = contact.ContactID,
                        NodeID = page.NodeID,
                        EventAttendeeRegisteredOn = DateTime.Now
                    });
                    
                    if(model.SubmitAction.Equals("text"))
                    {
                        result = model.ActionRelatedData;
                    }
                    else
                    {
                        return Redirect(model.ActionRelatedData);
                    }
                }
            }
            else
            {
                result = "Unable to register for event: contact not found.";
            }

            return Content(result);
        }
    }
}
