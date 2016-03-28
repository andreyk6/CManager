using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace CertifyMe.Service
{

    [ServiceContract]
    public interface IService<T1, T2>
    {
        [OperationContract]
        T1 GetById(Guid id);

        [OperationContract]
        Guid Add(T2 item);

        [OperationContract]
        bool RemoveById(Guid id);

        [OperationContract]
        bool Update(T1 item);

        [OperationContract]
        List<T1> GetAll();
    }
}