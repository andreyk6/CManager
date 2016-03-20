﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CertifyMe.Data
{
    public class EventComment : DmBase<EventComment>
    {
        private Guid _commentatorId;
        public User Commentator {
            get { return User.Items[_commentatorId]; }
            private set { _commentatorId = value.Id; }
        }

        private Guid _eventId;
        public Event Event
        {
            get { return Event.Items[_eventId]; }
            private set { _eventId = value.Id; }
        }

        public string Text { get; set; }

        public EventComment(User commentator, Event @event ) : base()
        {
            Commentator = commentator;
            Event = @event;
        }
    }
}