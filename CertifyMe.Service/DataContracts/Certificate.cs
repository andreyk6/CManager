using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace CertifyMe.Service.DataContracts
{
    [DataContract]
    public class Certificate : DmBaseDataContract
    {
        [DataMember]
        public Guid OwnerId { get; set; }
        [DataMember]
        public Guid EventId { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public int Place { get; set; }
    }
}