using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webApi.src.models
{
    public class Product : Entity
    {
        public override long? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Information { get; set; }
        public virtual Subcategory Subcategory { get; set; }
        public long SubcategoryId { get; set; }
        public long AvailableQuantity { get; set; }
        public DateTime LimitDate { get; set; }
        public DateTime PurchaseDate { get; set; }
        public List<Price> Prices { get; set; }
        public override DateTime? LastModification { get; set; }
        public override DateTime? RegisterDate { get; set; }
    }
}
