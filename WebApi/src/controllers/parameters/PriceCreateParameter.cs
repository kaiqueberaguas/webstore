using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApi.src.models;

namespace webApi.src.controllers.parameters
{
    public class PriceCreateParameter
    {
        public ProductParameter Product { get; set; }
        public double Amount { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }
        public bool IsPromotional { get; set; }

        public Price ToModel()
        {
            var price = new Price();
            if (Product != null) price.Product = Product.ToModel();
            price.Amount = Amount;
            price.InitialDate = InitialDate;
            price.FinalDate = FinalDate;
            price.IsPromotional = IsPromotional;
            return price;
        }

    }
}
