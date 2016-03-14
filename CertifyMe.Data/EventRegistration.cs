using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CertifyMe.Data
{
    public class EventRegistration : DmBase<EventRegistration>
    {
        private Guid _userId;
        public User User
        {
            get { return User.Items[_userId]; }
            set { _userId = value.Id; }
        }
        
        private Guid _eventId;
        public Event Event
        {
            get { return Event.Items[_eventId]; }
            set { _eventId = value.Id; }
        }

        public EventRegistration(User user, Event @event) : base()
        {
            User = user;
            Event = @event;
        }
    }
}