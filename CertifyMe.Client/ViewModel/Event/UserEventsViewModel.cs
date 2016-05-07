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
        public override void LoadEventsList()
        {
            Events = _eventClient.GetUserEvents(SystemUser.Instance.Id);
            EventsResult = Events;
        }
    }
}
