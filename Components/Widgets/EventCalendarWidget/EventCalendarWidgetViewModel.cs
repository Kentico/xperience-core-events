using CMS.DocumentEngine;
using System.Collections.Generic;

namespace Xperience.Core.Events
{
    public class EventCalendarWidgetViewModel
    {
        public IEnumerable<EventDto> Events { get; set; }
        public IEnumerable<CalendarDto> Calendars { get; set; }
        public string WidgetGUID { get; set; }
    }
}
