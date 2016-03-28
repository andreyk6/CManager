using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace CertifyMe.Data
{
    [DataContract]
    public class EventComment : DmBase<EventComment>
    {
        [DataMember(Name ="CommentatorId")]
        private Guid _commentatorId;
        [IgnoreDataMember]
        public User Commentator {
            get { return User.Items[_commentatorId]; }
            private set { _commentatorId = value.Id; }
        }

        [DataMember(Name ="EventId")]
        private Guid _eventId;
        [IgnoreDataMember]
        public Event Event
        {
            get { return Event.Items[_eventId]; }
            private set { _eventId = value.Id; }
        }

        [DataMember]
        public string Text { get; set; }

        public EventComment(User commentator, Event @event) : this(commentator.Id, @event.Id) { }
        public EventComment(Guid userId, Guid eventId) : base()
        {
            if (User.Items.ContainsKey(userId))
            {
                _commentatorId = userId;
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