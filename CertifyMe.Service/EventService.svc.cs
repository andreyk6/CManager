﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CertifyMe.Service.DataContracts;

namespace CertifyMe.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EventService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EventService.svc or EventService.svc.cs at the Solution Explorer and start debugging.
    public class EventService : IEventService
    {
        public Guid Add(Event @event)
        {
            if (Data.Event.Items.ContainsKey(@event.Id))
            {
                return Guid.Empty;
            }

            try
            {
                var eventModel = new Data.Event(@event.CompanyId, @event.StartDate, @event.EndDate)
                {
                    Name = @event.Name,
                    Description = @event.Description,
                    Location = @event.Location
                };
                return eventModel.Id;
            }
            catch (Exception e)
            {
                return Guid.Empty;
            }
        }

        public List<Event> GetAll()
        {
            return Data.Event.Items.Values.Select(e => e.ToEventContract()).ToList();
        }

        public Event GetById(Guid id)
        {
            if (Data.Event.Items.Keys.Contains(id))
            {
                return Data.Event.Items[id].ToEventContract();
            }

            return null;
        }

        public List<Event> GetUserEvents(Guid userId)
        {
            if (Data.User.Items.Keys.Contains(userId))
            {
                return Data.User.Items[userId].Events.Select(e => e.ToEventContract()).ToList();
            }
            return null;
        }

        public bool RegisterUser(Guid userId, Guid eventId)
        {
            try
            {
                new Data.EventRegistration(userId, eventId);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool RemoveById(Guid id)
        {
            if (Data.Event.Items.Keys.Contains(id))
            {
                Data.Event.Items.Remove(id);
                return true;
            }
            return false;
        }

        public bool Update(Event @event)
        {
            if (Data.Event.Items.Keys.Contains(@event.Id))
            {
                Data.Event.Items[@event.Id].Description = @event.Description;
                Data.Event.Items[@event.Id].Name = @event.Name;
                Data.Event.Items[@event.Id].Location = @event.Location;
                Data.Event.Items[@event.Id].StartDate = @event.StartDate;
                Data.Event.Items[@event.Id].EndDate = @event.EndDate;
                return true;
            }

            return false;
        }
    }
}
