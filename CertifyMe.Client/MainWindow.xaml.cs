using System.Windows;
using CertifyMe.Client.CompanyServiceReference;
using CertifyMe.Client.EventServiceReference;
using CertifyMe.Client.UserServiceReference;
using System;

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

            CreateUsers();
            var users = userService.GetAll();

            CreateCompanyForEachUser(users);
            var companies = companyService.GetAll();

            CreateEventForEachCompany(companies);
            var events = eventService.GetAll();

            RegisterEachUserOnEachEvent(users, events);
            foreach(var user in users)
            {
                var userEvents = eventService.GetUserEvents(user.Id);
            }
            //users = null;
            //users = null;
        }

        private void RegisterEachUserOnEachEvent(User[] users, Event[] events)
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

        private void CreateEventForEachCompany(Company[] companies)
        {
            for (int i = 0; i < companies.Length; i++)
            {
                var @event = new Event()
                {
                    CompanyId = companies[i].Id,
                    Name = "Event " + i,
                    Description = "Event description",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.Add(new TimeSpan())
                };
                eventService.Add(@event);
            }
        }

        private void CreateCompanyForEachUser(User[] users)
        {
            for (var i = 0; i < users.Length; i++)
            {
                var company = new Company()
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
                var user = new User()
                {
                    Age = 18 + i,
                    FirstName = "User",
                    LastName = "Generated" + i,
                };
                userService.Add(user);
            }
        }
    }
}
