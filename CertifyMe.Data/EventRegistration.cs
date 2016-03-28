using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace CertifyMe.Data
{
    [DataContract]
    public class EventRegistration : DmBase<EventRegistration>
    {
        [DataMember(Name = "UserId")]
        private Guid _userId;
        [IgnoreDataMember]
        public User User
        {
            get { return User.Items[_userId]; }
            set { _userId = value.Id; }
        }

        [DataMember(Name = "EventId")]
        private Guid _eventId;
        [IgnoreDataMember]
        public Event Event
        {
            get { return Event.Items[_eventId]; }
            set { _eventId = value.Id; }
        }

        public EventRegistration(User user, Event @event) : this(user.Id, @event.Id) { }
        public EventRegistration(Guid userId, Guid eventId) : base()
        {
            if (User.Items.ContainsKey(userId))
            {
                _userId = userId;
            }
            else
            {
                throw new KeyNotFoundException("User not found");
            }

            if (Event.Items.ContainsKey(eventId))
            {
                _eventId = eventId;
            }
            else
            {
                throw new KeyNotFoundException("Event not found");
            }
        }
    }
}