using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertifyMe.Data
{
    public class Class1
    {
        public void Main()
        {
            User user = new User("Andrii", "Konovalenko", 19);
            var intelInc = new Company(user)
            {
                Name="Intel Inc."
            };

            var @event = new Event(intelInc, DateTime.Today, DateTime.MaxValue);

            var eventRegistration = new EventRegistration(user, @event);

            var firstPlaceAward = new Certificate(eventRegistration.User, eventRegistration.Event);
            
            var comment = new  EventComment(user,@event)
            {
                Text = "Hello"
            };
        }
    }
}
