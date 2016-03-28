using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace CertifyMe.Data
{
    [DataContract]
    public class DmBase<T> where T:DmBase<T>
    {
        [IgnoreDataMember]
        public static readonly Dictionary<Guid, T> Items = new Dictionary<Guid, T>();
        [DataMember]
        public Guid Id { get; private set; }
        [DataMember]
        public DateTime CreationTime { get; private set; }

        public DmBase()
        {
            Id = Guid.NewGuid();
            Items.Add(Id, (T)this);
            CreationTime = DateTime.Now;
        }
    }
}