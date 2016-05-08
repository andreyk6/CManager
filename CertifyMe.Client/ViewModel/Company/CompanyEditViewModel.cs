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
    public class CompanyEditViewModel : ViewModelBase
    {
        CompanyServiceClient _companyService = new CompanyServiceClient();

        private Company _company;
        public Company Company
        {
            get
            {
                return _company;
            }
            set
            {
                if (_company == value)
                    return;
                _company = value;
                OnPropertyChanged("Company");
            }
        }

        public string Name
        {
            get
            {
                return Company.Name;
            }
            set
            {
                if (Company.Name == value)
                    return;
                Company.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Description
        {
            get
            {
                return Company.Description;
            }
            set
            {
                if (Company.Description == value)
                    return;
                Company.Description = value;
                OnPropertyChanged("Description");
            }
        }

        public CompanyEditViewModel(Guid id)
        {
            Company = _companyService.GetById(id);
            UpdateCommand = new BaseCommand(updateExecute, updateCanExecute);
        }

        public ICommand UpdateCommand;
        bool updateCanExecute(object param)
        {
            if (!string.IsNullOrWhiteSpace(Name) || !string.IsNullOrWhiteSpace(Description))
            {
                return true;
            }
            return false;
        }

        void updateExecute(object param)
        {
            if (_companyService.Update(Company))
            {
                Name = "";
                Description = "";
            }
        }
    }
}
