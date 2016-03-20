using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CertifyMe.Service
{
    [DataContract]
    public class User:DmBaseDataContract
    {
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public int Age { get; set; }
        public User(string firstName, string lastName, int age):base()
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        //public List<Company> Companies
        //{
        //    get { return Company.Items.Values.Where(_ => _.Owner == this).ToList(); }
        //}
        //public List<Event> Events
        //{
        //    get { return Event.Items.Values.Where(_ => _.Participants.Contains(this)).ToList(); }
        //}
        //public List<Certificate> Certificates
        //{
        //    get { return Certificate.Items.Values.Where(_ => _.Owner == this).ToList(); }
        //}

        public static User ToUserModel(Data.User user)
        {
            return new User(user.FirstName, user.LastName, user.Age)
            {
                Id = user.Id,
                CreationTime = user.CreationTime
            };
        }
    }
}