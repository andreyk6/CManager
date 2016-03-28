using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CertifyMe.Service.DataContracts
{
    [DataContract]
    public class UserInfo : DmBaseDataContract
    {
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public int Age { get; set; }
        public UserInfo(string firstName, string lastName, int age) : base()
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }
    }
}