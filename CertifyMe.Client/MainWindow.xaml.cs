using System.Windows;
using CertifyMe.Client.CompanyServiceReference;
using CertifyMe.Client.EventServiceReference;
using CertifyMe.Client.UserServiceReference;
using System;
using CertifyMe.Client.View;
using CertifyMe.Client.ViewModel;

namespace CertifyMe.Client
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UserServiceClient userService = new UserServiceClient();
        EventServiceClient eventService = new EventServiceClient();
        CompanyServiceClient companyService = new CompanyServiceClient();

        public MainWindow()
        {
            InitializeComponent();


            if (userService.GetAll().Length == 0)
            {
                CreateTestInstances();
            }

            var viewModel = new WindowViewModel();
            viewModel.CurrentView = new LoginPage();

            this.DataContext = viewModel;

            EventsListFrame.Content = new EventsListPage(new EventsListViewModel());
            ProfileFrame.Content = new UserProfilePage();
            MyEventsFrame.Content = new EventsListPage(new UserEventsViewModel());
            MyCertificatesFrame.Content = new UserCertificatesPage();
            MyCompaniesFrame.Content = new UserCompaniesPage();
            LoginFrame.Content = viewModel.CurrentView;
        }

        public void CreateTestInstances()
        {
            CreateUsers();
            var users = userService.GetAll();

            CreateCompanyForEachUser(users);
            var companies = companyService.GetAll();

            CreateEventForEachCompany(companies);
            var events = eventService.GetAll();

            RegisterEachUserOnEachEvent(users, events);
        }
        private void RegisterEachUserOnEachEvent(UserServiceReference.User[] users, Event[] events)
        {
            for (int i = 0; i < events.Length; i++)
            {
                for (int j = 0; j < users.Length; j++)
                {
                    var eventCompanyOwnerId = companyService.GetById(events[i].CompanyId).OwnerId;
                    if (users[j].Id != eventCompanyOwnerId)
                    {
                        eventService.RegisterUser(users[j].Id, events[i].Id);
                    }
                }
            }
        }

        static Random rnd = new Random();
        string[] locations = {"Ukraine, Kiev", "Ukraine, Lviv", "USA, Arizona, Phoenix", "USA, Boston", "Ukraine", "USA" };
        private string GetRandomLocation()
        {
            return locations[rnd.Next(locations.Length)];
        }
        private void CreateEventForEachCompany(Company[] companies)
        {
            for (int i = 0; i < companies.Length; i++)
            {
                var @event = new EventInfo()
                {
                    CompanyId = companies[i].Id,
                    Name = "Event " + i,
                    Description = "Event description",
                    StartDate = DateTime.Now + new TimeSpan(rnd.Next(4),0,0,0),
                    Location = GetRandomLocation(),
                    EndDate = DateTime.Now.Add(new TimeSpan(10,5,45,0))
                };
                eventService.Add(@event);
            }
        }

        private void CreateCompanyForEachUser(UserServiceReference.User[] users)
        {
            for (var i = 0; i < users.Length; i++)
            {
                var company = new CompanyInfo()
                {
                    OwnerId = users[i].Id,
                    Name = "Company " + i,
                    Description = "Desciption"
                };
                companyService.Add(company);
            }
        }

        private void CreateUsers()
        {
            for (var i = 0; i < 10; i++)
            {
                var user = new UserInfo()
                {
                    Age = 18 + i,
                    FirstName = "User",
                    LastName = "Generated" + i,
                    Login = "login" + i,
                    Password = "password"
                };
                userService.Add(user);
            }
        }
    }
}
