using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CertifyMe.Data;
using CertifyMe.Service.DataContracts;

namespace CertifyMe.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EventService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EventService.svc or EventService.svc.cs at the Solution Explorer and start debugging.
    public class EventService : IEventService
    {
        public Guid Add(EventInfo eventInfo)
        {
            try
            {
                var @event = new Event(eventInfo.CompanyId, eventInfo.StartDate, eventInfo.EndDate)
                {
                    Name = eventInfo.Name,
                    Description = eventInfo.Description,
                    Location = eventInfo.Location
                };
                return @event.Id;
            }
            catch (Exception e)
            {
                return Guid.Empty;
            }
        }

        public List<Event> GetAll()
        {
            return Event.Items.Values.ToList();
        }

        public Event GetById(Guid id)
        {
            if (Event.Items.Keys.Contains(id))
            {
                return Event.Items[id];
            }

            return null;
        }

        public bool RemoveById(Guid id)
        {
            if (Event.Items.Keys.Contains(id))
            {
                Event.Items.Remove(id);
                return true;
            }
            return false;
        }

        public bool Update(Event @event)
        {
            if (Event.Items.Keys.Contains(@event.Id))
            {
                Event.Items[@event.Id].Description = @event.Description;
                Event.Items[@event.Id].Name = @event.Name;
                Event.Items[@event.Id].Location = @event.Location;
                Event.Items[@event.Id].StartDate = @event.StartDate;
                Event.Items[@event.Id].EndDate = @event.EndDate;
                return true;
            }

            return false;
        }

        public bool RegisterUser(Guid userId, Guid eventId)
        {
            try
            {
                new EventRegistration(userId, eventId);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool UnregisterUser(Guid userId, Guid eventId)
        {
            var eventRegistration = EventRegistration.Items.Values.Where(r => r.Event.Id == eventId && r.User.Id == userId).Single();
            if (eventRegistration != null)
            {
                return EventRegistration.Items.Remove(eventRegistration.Id);
            }
            return false;
        }

        public List<EventComment> GetComments(Guid eventId)
        {
            if (User.Items.Keys.Contains(eventId))
            {
                return Event.Items[eventId].Comments;
            }
            return null;
        }

        public List<Event> GetUserEvents(Guid userId)
        {
            if (User.Items.Keys.Contains(userId))
            {
                return User.Items[userId].Events;
            }
            return null;
        }

        public List<Event> GetCompanyEvents(Guid companyId)
        {
            if (Company.Items.Keys.Contains(companyId))
            {
                return Company.Items[companyId].Events.ToList();
            }
            return null;
        }
    }
}
