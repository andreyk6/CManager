using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CertifyMe.Data
{
    public class Company : DmBase<Company>
    {
        private Guid _ownerId;
        public User Owner
        {
            get { return User.Items[_ownerId]; }
            private set { _ownerId = value.Id; }
        }

        public string Name { get; set; }
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

        public List<Event> Events
        {
            get { return Event.Items.Values.Where(e => e.Company == this).ToList(); }
        }
    }
}