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
        public long? ProductId { get; set; }
        public decimal? Amount { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }
        public bool? IsPromotional { get; set; }
        public override DateTime? LastModification { get; set; }
        public override DateTime? RegisterDate { get; set; }
        public void Update(Price price)
        {
            if (price.Amount != null) Amount = price.Amount;
            if (price.Product != null && price.Product.Id != null)
            {
                Product = price.Product;
                ProductId = price.Product.Id;
            }
            if (price.IsPromotional != null) IsPromotional = price.IsPromotional;
            if (price.InitialDate != null) InitialDate = price.InitialDate;
            if (price.FinalDate != null) FinalDate = price.FinalDate;
        }
    }
}
