using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace CertifyMe.Service.DataContracts
{
    [DataContract]
    public class CompanyInfo : DmBaseDataContract
    {
        [DataMember]
        public Guid OwnerId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
    }
}