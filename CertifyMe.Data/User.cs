using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CertifyMe.Data
{
    public class User : DmBase<User>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public User(string firstName, string lastName, int age) : base()
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public List<Company> Companies
        {
            get { return Company.Items.Values.Where(_ => _.Owner == this).ToList(); }
        }
        public List<Event> Events
        {
            get { return Event.Items.Values.Where(_ => _.Participants.Contains(this)).ToList(); }
        }
        public List<Certificate> Certificates
        {
            get { return Certificate.Items.Values.Where(_ => _.Owner == this).ToList(); }
        }
    }
}