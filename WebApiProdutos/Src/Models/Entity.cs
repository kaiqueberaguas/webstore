using System;

namespace WebApiProdutos.Src.Models
{
    public abstract class Entity
    {
        public virtual long? Id { get; set; }
        public virtual long? Code { get; set; }
        public virtual DateTime? LastModification { get; set; }
        public virtual DateTime? RegisterDate { get; set; }
        public virtual bool? IsActive { get; set; }

        public virtual void PrepareToCreateRegister()
        {
            Id = null;
            LastModification = DateTime.Now;
            RegisterDate = DateTime.Now;
        }

        public void UpdateRecorde() => LastModification = DateTime.Now;
    }
}
