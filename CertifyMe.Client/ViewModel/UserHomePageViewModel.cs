using CertifyMe.Client.CompanyServiceReference;
using CertifyMe.Client.EventServiceReference;
using CertifyMe.Client.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CertifyMe.Client.ViewModel
{
    public class UserHomePageViewModel : ViewModelBase
    {
        EventServiceClient _eventClient = new EventServiceClient();
        CompanyServiceClient _companyClient = new CompanyServiceClient();

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

        IEnumerable<Event> _eventsResult;
        public IEnumerable<Event> EventsResult
        {
            get { return _eventsResult; }
            set
            {
                if (_eventsResult == value)
                    return;
                _eventsResult = value;
                OnPropertyChanged("EventsResult");
            }
        }


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

        Company _selectedCompany;
        public Company SelectedCompany
        {
            get
            {
                return _selectedCompany;
            }
            set
            {
                if (_selectedCompany == value)
                    return;
                _selectedCompany = value;

                OnPropertyChanged("SelectedCompany");
            }
        }

        DateTime _startDate = DateTime.Now.Date;
        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                if (_startDate == value)
                    return;
                _startDate = value;
                OnPropertyChanged("StartDate");
            }
        }

        string _searchLocation;
        public string SearchLocation
        {
            get { return _searchLocation; }
            set
            {
                if (value == _searchLocation)
                    return;
                _searchLocation = value;
                OnPropertyChanged("SearchLocation");
            }
        }

        public UserHomePageViewModel()
        {
            Events = _eventClient.GetAll();
            EventsResult = Events;
            UpdateSearch = new BaseCommand(_updateSearchExecute, _updateSearchCanExecute);

            var emptyCompany = new Company() { Name = "All" };
            SelectedCompany = emptyCompany;

            List<Company> companies = new List<Company>(_companyClient.GetAll());
            companies.Insert(0, emptyCompany);
            Companies = companies.ToArray();
        }


        private bool _updateSearchCanExecute(object parameter)
        {
            return true;
        }

        private void _updateSearchExecute(object parameter)
        {
            IEnumerable<Event> searchResult = Events.Where(e => e.StartDate >= StartDate);

            if (SelectedCompany.Name != "All")
                searchResult = Events.Where(e => e.CompanyId == SelectedCompany.Id);

            if (!string.IsNullOrWhiteSpace(SearchLocation))
                searchResult = searchResult.Where(e => e.Location.Contains(SearchLocation));

            EventsResult = searchResult;
        }

        public ICommand UpdateSearch { get; set; }
    }
}
