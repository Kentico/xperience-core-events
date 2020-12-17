using CMS.DataEngine;

namespace Events
{
    /// <summary>
    /// Declares members for <see cref="EventAttendeeInfo"/> management.
    /// </summary>
    public partial interface IEventAttendeeInfoProvider : IInfoProvider<EventAttendeeInfo>, IInfoByIdProvider<EventAttendeeInfo>
    {
    }
}