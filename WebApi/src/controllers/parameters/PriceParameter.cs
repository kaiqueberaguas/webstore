using System;
using webApi.src.controllers.parameters;
using webApi.src.models;

namespace webApi.src.parameters
{
    public class PriceParameter
    {
        public long Id { get; set; }
        public ProductParameter Product { get; set; }
        public decimal Amount { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }
        public bool IsPromotional { get; set; }
        
        public Price ToModel()
        {
            var price = new Price();
            price.Id = Id;
            if(Product != null )price.Product = Product.ToModel();
            price.Amount = Amount;
            price.InitialDate = InitialDate;
            price.FinalDate = FinalDate;
            price.IsPromotional = IsPromotional;
            return price;
        }
    }
}
