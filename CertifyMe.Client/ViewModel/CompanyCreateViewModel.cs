using CertifyMe.Client.CompanyServiceReference;
using CertifyMe.Client.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CertifyMe.Client.ViewModel
{
    public class CompanyCreateViewModel : ViewModelBase
    {
        CompanyServiceClient _companyService = new CompanyServiceClient();

        private CompanyInfo _companyInfo;
        public CompanyInfo CompanyInfo
        {
            get
            {
                return _companyInfo;
            }
            set
            {
                if (_companyInfo == value)
                    return;
                _companyInfo = value;
                OnPropertyChanged("CompanyInfo");
            }
        }

        public string Name
        {
            get
            {
                return CompanyInfo.Name;
            }
            set
            {
                if (CompanyInfo.Name == value)
                    return;
                CompanyInfo.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Description
        {
            get
            {
                return CompanyInfo.Description;
            }
            set
            {
                if (CompanyInfo.Description == value)
                    return;
                CompanyInfo.Description = value;
                OnPropertyChanged("Description");
            }
        }

        public CompanyCreateViewModel()
        {
            CompanyInfo = new CompanyInfo();
        }

        public void CreateExecute()
        {
            if (!string.IsNullOrWhiteSpace(Name) || !string.IsNullOrWhiteSpace(Description))
            {
                CompanyInfo.OwnerId = SystemUser.Instance.Id;
                CompanyInfo.CreationTime = DateTime.Now;

                if (_companyService.Add(CompanyInfo) != Guid.Empty)
                {
                    Name = "";
                    Description = "";
                }
            }
        }
    }
}
