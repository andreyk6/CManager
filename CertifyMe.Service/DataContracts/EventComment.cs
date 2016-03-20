using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace CertifyMe.Service.DataContracts
{
    [DataContract]
    public class EventComment : DmBaseDataContract
    {
        [DataMember]
        public Guid CommentatorId { get; set; }
        [DataMember]
        public Guid EventId { get; set; }
        [DataMember]
        public string Text { get; set; }
    }
}