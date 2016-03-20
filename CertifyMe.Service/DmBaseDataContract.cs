using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CertifyMe.Service
{
    [DataContract]
    public class DmBaseDataContract
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public DateTime CreationTime { get; set; }

        public DmBaseDataContract()
        {
            CreationTime = DateTime.Now;
        }
    }
}