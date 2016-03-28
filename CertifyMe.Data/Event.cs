using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.AccessControl;
using System.Text;

namespace CertifyMe.Data
{
    [DataContract]
    public class Event : DmBase<Event>
    {
        [DataMember(Name = "CompanyId")]
        private Guid _companyId;
        [IgnoreDataMember]
        public Company Company
        {
            get { return Company.Items[_companyId]; }
            private set { _companyId = value.Id; }
        }

        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Location { get; set; }
        [DataMember]
        public DateTime StartDate { get; set; }
        [DataMember]
        public DateTime EndDate { get; set; }

        public Event(Company company, DateTime startDate, DateTime endDate) : this(company.Id, startDate, endDate) { }
        public Event(Company company) : this(company.Id, DateTime.Today, DateTime.Today) { }
        public Event(Guid companyId) : this(companyId, DateTime.Today, DateTime.Today) { }
        public Event(Guid companyId, DateTime startDate, DateTime endDate) : base()
        {
            if (Company.Items.ContainsKey(companyId))
            {
                _companyId = companyId;
            }
            else
            {
                throw new KeyNotFoundException("Company not found");
            }

            StartDate = startDate;
            EndDate = endDate;
        }

        [IgnoreDataMember]
        public List<User> Participants
        {
            get { return EventRegistration.Items.Values.Where(r => r.Event == this).Select(r => r.User).ToList(); }
        }
        [IgnoreDataMember]
        public List<Certificate> Certificates
        {
            get { return Certificate.Items.Values.Where(_ => _.Event == this).ToList(); }
        }
        [IgnoreDataMember]
        public List<EventComment> Comments
        {
            get { return EventComment.Items.Values.Where(_ => _.Event == this).ToList(); }
        }
    }
}