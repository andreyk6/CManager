using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CertifyMe.Service.DataContracts
{
    [DataContract]
    public class User : DmBaseDataContract
    {
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public int Age { get; set; }
        public User(string firstName, string lastName, int age) : base()
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public List<Company> Companies
        {
            get { return Data.Company.Items.Values.Where(c => c.Owner.Id == Id).Select(c => c.ToCompanyContract()).ToList(); }
        }
        public List<Event> Events
        {
            get { return Data.Event.Items.Values.Where(e => e.Participants.Select(p => p.Id).Contains(Id)).Select(e => e.ToEventContract()).ToList(); }
        }
        public List<Certificate> Certificates
        {
            get { return Data.Certificate.Items.Values.Where(c => c.Owner.Id == Id).Select(c=>c.ToCertificateContract()).ToList(); }
        }
    }
}