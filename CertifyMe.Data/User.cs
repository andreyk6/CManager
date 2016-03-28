using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace CertifyMe.Data
{
    [DataContract]
    public class User : DmBase<User>
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

        [IgnoreDataMember]
        public List<Company> Companies
        {
            get { return Company.Items.Values.Where(_ => _.Owner == this).ToList(); }
        }
        [IgnoreDataMember]
        public List<Event> Events
        {
            get { return EventRegistration.Items.Values.Where(r=>r.User == this).Select(r=>r.Event).ToList(); }
        }
        [IgnoreDataMember]
        public List<Certificate> Certificates
        {
            get { return Certificate.Items.Values.Where(_ => _.Owner == this).ToList(); }
        }
    }
}