using CMS.DataEngine;

namespace Events
{
    /// <summary>
    /// Class providing <see cref="EventAttendeeInfo"/> management.
    /// </summary>
    [ProviderInterface(typeof(IEventAttendeeInfoProvider))]
    public partial class EventAttendeeInfoProvider : AbstractInfoProvider<EventAttendeeInfo, EventAttendeeInfoProvider>, IEventAttendeeInfoProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventAttendeeInfoProvider"/> class.
        /// </summary>
        public EventAttendeeInfoProvider()
            : base(EventAttendeeInfo.TYPEINFO)
        {
        }
    }
}