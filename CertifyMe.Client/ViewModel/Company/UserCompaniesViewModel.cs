using CertifyMe.Client.CompanyServiceReference;
using CertifyMe.Client.EventServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertifyMe.Client.ViewModel
{
    public class UserCompaniesViewModel : ViewModelBase
    {
        protected EventServiceClient _eventClient = new EventServiceClient();
        CompanyServiceClient _companyClient = new CompanyServiceClient();

        Company[] _companies;
        public Company[] Companies
        {
            get { return _companies; }
            set
            {
                if (_companies == value)
                    return;
                _companies = value;
                OnPropertyChanged("Companies");
            }
        }

        public UserCompaniesViewModel()
        {
            SystemUser.Instance.PropertyChanged += (o, args) =>
            {
                if (args.PropertyName == "Id") LoadCompaniesList();
            };

            LoadCompaniesList();
        }

        public virtual void LoadCompaniesList()
        {
            Companies = _companyClient.GetUserCompanies(SystemUser.Instance.Id);
        }
    }
}
