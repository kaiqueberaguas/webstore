using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webApi.src.models
{
    public abstract class Entity
    {
        public virtual long? Id { get; set; }
        public virtual DateTime? LastModification { get; set; }
        public virtual DateTime? RegisterDate { get; set; }

        public void PrepareCreateRecord()
        {
            Id = null;
            LastModification = DateTime.Now;
            RegisterDate = DateTime.Now;
        }

        public void UpdateRecorde() => LastModification = DateTime.Now;
    }
}
