using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webApi.src.models
{
    public class Price : Entity
    {
        public override long? Id { get; set; }
        public virtual Product Product { get; set; }
        public long ProductId { get; set; }
        public decimal Amount { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }
        public bool IsPromotional { get; set; }
        public override DateTime? LastModification { get; set; }
        public override DateTime? RegisterDate { get; set; }
    }
}
