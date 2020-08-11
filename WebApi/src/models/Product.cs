using Castle.Core.Internal;
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
        public long? SubcategoryId { get; set; }
        public long? AvailableQuantity { get; set; }
        public DateTime LimitDate { get; set; }
        public DateTime PurchaseDate { get; set; }
        public List<Price> Prices { get; set; }
        public override DateTime? LastModification { get; set; }
        public override DateTime? RegisterDate { get; set; }
        public void Update(Product product)
        {
            if (!product.Name.IsNullOrEmpty()) Name = product.Name; 
            if (!product.Description.IsNullOrEmpty())Description = product.Description; 
            if (!product.Information.IsNullOrEmpty()) Information = product.Information; 
            if (product.Subcategory != null && product.Subcategory.Id != null)
            {
                Subcategory = product.Subcategory;
                SubcategoryId = product.Subcategory.Id;
            }

            if (product.LimitDate != null) LimitDate = product.LimitDate; 
            if (product.PurchaseDate != null) PurchaseDate = product.PurchaseDate; 
            if (product.AvailableQuantity != null) AvailableQuantity = product.AvailableQuantity; 
        }
    }
}
