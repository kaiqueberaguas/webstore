using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using webApi.src.models;

namespace webApi.src.controllers.parameters
{
    public class ProductCreateParameter
    {
        [MaxLength(25)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        [MaxLength(400)]
        public string Information { get; set; }
        public long AvailableQuantity { get; set; }
        public DateTime LimitDate { get; set; }
        public DateTime PurchaseDate { get; set; }
        [Required]
        public SubcategoryParameter Subcategory { get; set; }
        
        public Product ToModel()
        {
            var product = new Product();
            product.Name = Name;
            product.Description = Description;
            product.Information = Information;
            product.AvailableQuantity = AvailableQuantity;
            product.LimitDate = LimitDate;
            product.PurchaseDate = PurchaseDate;
            product.Subcategory = Subcategory.ToModel();
            return product;
        }
    }
}
