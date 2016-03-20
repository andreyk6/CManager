using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace CertifyMe.Service.DataContracts
{
    [DataContract]
    public class EventRegistration : DmBaseDataContract
    {
        [DataMember]
        public Guid UserId { get; set; }

        [DataMember]
        public Guid EventId { get; set; }
    }
}