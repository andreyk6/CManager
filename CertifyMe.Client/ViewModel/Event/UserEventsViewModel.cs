using CertifyMe.Client.UserServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertifyMe.Client.ViewModel
{
    public class UserEventsViewModel : EventsListViewModel
    {
        public async override void LoadEventsList()
        {
            Events = await _eventClient.GetUserEventsAsync(SystemUser.Instance.Id);
            EventsResult = Events;
        }
    }
}
