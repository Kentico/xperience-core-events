using System;
using System.Data;
using System.Runtime.Serialization;

using CMS;
using CMS.DataEngine;
using CMS.Helpers;
using Events;

[assembly: RegisterObjectType(typeof(EventAttendeeInfo), EventAttendeeInfo.OBJECT_TYPE)]

namespace Events
{
    /// <summary>
    /// Data container class for <see cref="EventAttendeeInfo"/>.
    /// </summary>
    [Serializable]
    public partial class EventAttendeeInfo : AbstractInfo<EventAttendeeInfo, IEventAttendeeInfoProvider>
    {
        /// <summary>
        /// Object type.
        /// </summary>
        public const string OBJECT_TYPE = "events.eventattendee";


        /// <summary>
        /// Type information.
        /// </summary>
#warning "You will need to configure the type info."
        public static readonly ObjectTypeInfo TYPEINFO = new ObjectTypeInfo(typeof(EventAttendeeInfoProvider), OBJECT_TYPE, "Events.EventAttendee", "EventAttendeeID", null, "EventAttendeeGuid", null, null, null, null, null, null)
        {
            ModuleName = "Xperience.Events",
            TouchCacheDependencies = true,
        };


        /// <summary>
        /// Event attendee ID.
        /// </summary>
        [DatabaseField]
        public virtual int EventAttendeeID
        {
            get
            {
                return ValidationHelper.GetInteger(GetValue("EventAttendeeID"), 0);
            }
            set
            {
                SetValue("EventAttendeeID", value);
            }
        }


        /// <summary>
        /// Node ID.
        /// </summary>
        [DatabaseField]
        public virtual int NodeID
        {
            get
            {
                return ValidationHelper.GetInteger(GetValue("NodeID"), 0);
            }
            set
            {
                SetValue("NodeID", value, 0);
            }
        }


        /// <summary>
        /// Contact ID.
        /// </summary>
        [DatabaseField]
        public virtual int ContactID
        {
            get
            {
                return ValidationHelper.GetInteger(GetValue("ContactID"), 0);
            }
            set
            {
                SetValue("ContactID", value, 0);
            }
        }


        /// <summary>
        /// Event attendee registered on.
        /// </summary>
        [DatabaseField]
        public virtual DateTime EventAttendeeRegisteredOn
        {
            get
            {
                return ValidationHelper.GetDateTime(GetValue("EventAttendeeRegisteredOn"), DateTimeHelper.ZERO_TIME);
            }
            set
            {
                SetValue("EventAttendeeRegisteredOn", value, DateTimeHelper.ZERO_TIME);
            }
        }


        /// <summary>
        /// Event attendee guid.
        /// </summary>
        [DatabaseField]
        public virtual Guid EventAttendeeGuid
        {
            get
            {
                return ValidationHelper.GetGuid(GetValue("EventAttendeeGuid"), Guid.Empty);
            }
            set
            {
                SetValue("EventAttendeeGuid", value);
            }
        }


        /// <summary>
        /// Deletes the object using appropriate provider.
        /// </summary>
        protected override void DeleteObject()
        {
            Provider.Delete(this);
        }


        /// <summary>
        /// Updates the object using appropriate provider.
        /// </summary>
        protected override void SetObject()
        {
            Provider.Set(this);
        }


        /// <summary>
        /// Constructor for de-serialization.
        /// </summary>
        /// <param name="info">Serialization info.</param>
        /// <param name="context">Streaming context.</param>
        protected EventAttendeeInfo(SerializationInfo info, StreamingContext context)
            : base(info, context, TYPEINFO)
        {
        }


        /// <summary>
        /// Creates an empty instance of the <see cref="EventAttendeeInfo"/> class.
        /// </summary>
        public EventAttendeeInfo()
            : base(TYPEINFO)
        {
        }


        /// <summary>
        /// Creates a new instances of the <see cref="EventAttendeeInfo"/> class from the given <see cref="DataRow"/>.
        /// </summary>
        /// <param name="dr">DataRow with the object data.</param>
        public EventAttendeeInfo(DataRow dr)
            : base(TYPEINFO, dr)
        {
        }
    }
}