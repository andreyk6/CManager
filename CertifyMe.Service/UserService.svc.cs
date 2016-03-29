using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using CertifyMe.Data;
using CertifyMe.Service.DataContracts;

namespace CertifyMe.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class UserService : IUserService
    {
        public Guid Add(UserInfo userInfo)
        {
            var user = new Data.User(userInfo.FirstName, userInfo.LastName, userInfo.Age, userInfo.Login, userInfo.Password);
            return user.Id;
        }

        public List<User> GetAll()
        {
            return Data.User.Items.Values.ToList();
        }

        public User GetById(Guid id)
        {
            if (Data.User.Items.Keys.Contains(id))
            {
                return Data.User.Items[id];
            }
            else {
                return null;
            }
        }

        public bool RemoveById(Guid id)
        {
            if (Data.User.Items.Keys.Contains(id))
            {
                Data.User.Items.Remove(id);
                return true;
            }
            else {
                return false;
            }
        }

        public bool Update(User user)
        {
            if (Data.User.Items.Keys.Contains(user.Id))
            {
                Data.User.Items[user.Id].Age = user.Age;
                Data.User.Items[user.Id].FirstName = user.FirstName;
                Data.User.Items[user.Id].LastName = user.LastName;
                return true;
            }
            else {
                return false;
            }
        }

        public Guid GetUserByCredentials(string login, string password)
        {
            var user = User.Items.Values.Where(u => u.Login == login && u.Password == password).FirstOrDefault();

            if (user == null)
                return Guid.Empty;

            return user.Id;
        }
    }
}
