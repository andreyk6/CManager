using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;

namespace CertifyMe.Data
{
    public class Event : DmBase<Event>
    {
        private Guid _companyId;
        public Company Company
        {
            get { return Company.Items[_companyId]; }
            private set { _companyId = value.Id; }
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
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

        public List<User> Participants
        {
            get { return EventRegistration.Items.Values.Where(r => r.Event == this).Select(r => r.User).ToList(); }
        }
        public List<Certificate> Certificates
        {
            get { return Certificate.Items.Values.Where(_ => _.Event == this).ToList(); }
        }
        public List<EventComment> Comments
        {
            get { return EventComment.Items.Values.Where(_ => _.Event == this).ToList(); }
        }
    }
}