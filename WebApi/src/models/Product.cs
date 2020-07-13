using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webApi.src.models
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Information { get; set; }
        public Subcategory Subcategory { get; set; }
        public long AvailableQuantity { get; set; }
        public DateTime LimitDate { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime LastModification { get; set; }
        public DateTime RegisterDate { get; set; }
        public string OriginRegister { get; set; }

    }
}
