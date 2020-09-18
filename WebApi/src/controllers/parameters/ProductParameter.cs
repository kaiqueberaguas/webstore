using System;
using System.ComponentModel.DataAnnotations;
using webApi.src.models;

namespace webApi.src.controllers.parameters
{
    public class ProductParameter
    {
        [Required]
        
        public long ProductCode { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public string Information { get; set; }
        
        public long AvailableQuantity { get; set; }

        public decimal Amount { get; set; }
        
        public DateTime LimitDate { get; set; }
        
        public DateTime PurchaseDate { get; set; }
        
        public long SubcategoryCode { get; set; }

        public Product ToModel() => new Product()
        {
            Code = ProductCode,
            Name = Name,
            Amount = Amount,
            Description = Description,
            Information = Information,
            AvailableQuantity = AvailableQuantity,
            LimitDate = LimitDate,
            PurchaseDate = PurchaseDate,
            Subcategory = new Subcategory() { Code = SubcategoryCode }
        };

    }
}
