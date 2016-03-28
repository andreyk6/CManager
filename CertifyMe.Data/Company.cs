using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace CertifyMe.Data
{
    [DataContract]
    public class Company : DmBase<Company>
    {
        [DataMember(Name = "OwnerId")]
        private Guid _ownerId;
        [IgnoreDataMember]
        public User Owner
        {
            get { return User.Items[_ownerId]; }
            private set { _ownerId = value.Id; }
        }

        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }

        public Company(User owner) : this(owner.Id) { }

        public Company(Guid userId) : base()
        {
            if (User.Items.ContainsKey(userId))
            {
                _ownerId = userId;
            }
            else
            {
                throw new KeyNotFoundException("User not found");
            }
        }

        [IgnoreDataMember]
        public List<Event> Events
        {
            get { return Event.Items.Values.Where(e => e.Company == this).ToList(); }
        }
    }
}