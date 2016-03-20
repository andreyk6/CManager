using CertifyMe.Service.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CertifyMe.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        User GetById(Guid id);

        [OperationContract]
        Guid Add(User user);

        [OperationContract]
        bool RemoveById(Guid id);

        [OperationContract]
        bool Update(User user);

        [OperationContract]
        List<User> GetAll();
    }
}
