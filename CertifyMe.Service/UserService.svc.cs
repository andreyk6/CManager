﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using CertifyMe.Data;

namespace CertifyMe.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class UserService : IUserService
    {
        public Guid Add(User user)
        {
            if (Data.User.Items.Keys.Contains(user.Id))
            {
                return Guid.Empty;
            }
            else {
                var userModel = new Data.User(user.FirstName, user.LastName, user.Age);
                return userModel.Id;
            }
        }

        public User GetById(Guid id)
        {
            if (Data.User.Items.Keys.Contains(id))
            {
                var user = Data.User.Items[id];
                return User.ToUserModel(user);
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
    }
}
