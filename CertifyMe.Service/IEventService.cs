﻿using CertifyMe.Data;
using CertifyMe.Service.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CertifyMe.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEventService" in both code and config file together.
    [ServiceContract]
    public interface IEventService : IService<Event, EventInfo>
    {
        [OperationContract]
        bool RegisterUser(Guid userId, Guid eventId);

        [OperationContract]
        bool UnregisterUser(Guid userId, Guid eventId);

        [OperationContract]
        bool AddComment(Guid userId, Guid eventId, string comment);

        [OperationContract]
        List<EventComment> GetComments(Guid eventId);

        [OperationContract]
        List<Event> GetUserEvents(Guid userId);

        [OperationContract]
        List<User> GetParticipants(Guid eventId);

        [OperationContract]
        List<Event> GetCompanyEvents(Guid companyId);
    }
}
