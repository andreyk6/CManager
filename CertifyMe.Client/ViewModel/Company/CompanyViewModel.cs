using CertifyMe.Client.CompanyServiceReference;
using CertifyMe.Client.EventServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertifyMe.Client.ViewModel
{
    public class CompanyViewModel: ViewModelBase
    {
        EventServiceClient _eventClient = new EventServiceClient();
        CompanyServiceClient _companyClient = new CompanyServiceClient();

        Company _company;
        public Company Company
        {
            get { return _company; }
            set
            {
                if (_company == value)
                    return;
                _company = value;
                OnPropertyChanged("Company");
                OnPropertyChanged("CompanyName");
                OnPropertyChanged("CompanyDescription");
            }
        }

        public string CompanyName
        {
            get
            {
                return Company.Name;
            }
        }

        public string CompanyDescription
        {
            get
            {
                return Company.Description;
            }
        }

        Event[] _events;
        public Event[] Events
        {
            get { return _events; }
            set
            {
                if (_events == value)
                    return;
                _events = value;
                OnPropertyChanged("Events");
            }
        }

        public CompanyViewModel(Guid companyId)
        {
            Company = _companyClient.GetById(companyId);
            Events = _eventClient.GetCompanyEvents(companyId);
        }
    }
}
