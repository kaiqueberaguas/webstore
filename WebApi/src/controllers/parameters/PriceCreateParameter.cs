using Castle.Core.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using webApi.src.models;

namespace webApi.src.controllers.parameters
{
    public class PriceCreateParameter
    {
        [Required]
        public long ProductId { get; set; }
        [Required]
        public decimal Amount { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }
        public bool IsPromotional { get; set; }

        public Price ToModel()
        {
            var price = new Price();
            price.Product.Id = ProductId;
            price.Amount = Amount;
            price.InitialDate = InitialDate == null || InitialDate < DateTime.Today ? DateTime.Today:InitialDate;
            price.FinalDate = FinalDate;
            price.IsPromotional = IsPromotional;
            return price;
        }

    }
}
