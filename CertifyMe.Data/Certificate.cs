using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CertifyMe.Data
{
    public class Certificate : DmBase<Certificate>
    {
        private Guid _ownerId;
        public User Owner
        {
            get { return User.Items[_ownerId]; }
            private set { _ownerId = value.Id; }
        }

        private Guid _eventId;
        public Event Event
        {
            get { return Event.Items[_eventId]; }
            private set { _eventId = value.Id; }
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public int Place { get; set; }

        public Certificate(User owner, Event @event) : base()
        {
            Owner = owner;
            Event = @event;
        }
    }
}