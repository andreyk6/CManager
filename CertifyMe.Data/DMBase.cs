using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CertifyMe.Data
{
    public class DmBase<T> where T:DmBase<T>
    {
        public static readonly Dictionary<Guid, T> Items = new Dictionary<Guid, T>();
         
        public Guid Id { get; private set; }
        public DateTime CreationTime { get; private set; }

        public DmBase()
        {
            Id = Guid.NewGuid();
            Items.Add(Id, (T)this);
            CreationTime = DateTime.Now;
        }
    }
}