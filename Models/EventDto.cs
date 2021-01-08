using System;
using System.Collections.Generic;
using System.Text;

namespace Xperience.Core.Events
{
    public class EventDto
    {
        #region "Schedule properties (automatically mapped)"

        public string ID { get; set; }
        public string CalendarId { get; set; }
        public bool IsAllDay { get; set; }
        public string Title { get; set; }
        public string Body { get; set; } = "Dummy value";
        public string Start { get; set; }
        public string End { get; set; }
        public string Location { get; set; }
        public string DueDateClass { get; set; }
        public string Category { get { return "time"; } }
        public string BgColor { get; set; }
        public string BorderColor { get; set; }
        public string Color { get; set; }

        #endregion

        #region "Custom properties"

        public bool ShowAttendeeCount { get; set; } = true;
        public bool ShowAttendeeNames { get; set; } = false;
        public string AttendeeNames { get; set; } = "";
        public int Capacity { get; set; }
        public int AttendeeCount { get; set; }
        public string Url { get; set; }
        public string Summary { get; set; }

        #endregion
    }
}
