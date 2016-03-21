using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace CertifyMe.Service
{

    [ServiceContract]
    public interface IService<T> where T: class
    {
        [OperationContract]
        T GetById(Guid id);

        [OperationContract]
        Guid Add(T item);

        [OperationContract]
        bool RemoveById(Guid id);

        [OperationContract]
        bool Update(T item);

        [OperationContract]
        List<T> GetAll();
    }
}