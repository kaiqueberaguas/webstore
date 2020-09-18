using System;
using System.ComponentModel.DataAnnotations;
using webApi.src.models;

namespace webApi.src.controllers.parameters
{
    public class ProductCreateParameter
    {
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

        [Required]
        [MaxLength(400)]
        public string Information { get; set; }

        public long AvailableQuantity { get; set; }

        public DateTime LimitDate { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public DateTime PurchaseDate { get; set; }

        [Required]
        public long SubcategoryCode { get; set; }

        public Product ToModel() => new Product()
        {
            Name = Name,
            Description = Description,
            Amount = Amount,
            Information = Information,
            AvailableQuantity = AvailableQuantity,
            LimitDate = LimitDate,
            PurchaseDate = PurchaseDate,
            Subcategory = new Subcategory { Code = SubcategoryCode }
        };
    }
}
