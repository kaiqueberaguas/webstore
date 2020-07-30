using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webApi.src.interfaces
{
    public interface IEntity
    {
        public long Id { get; set; }
        public DateTime LastModification { get; set; }
        public DateTime RegisterDate { get; set; }
        public string OriginRegister { get; set; }
    }
}
