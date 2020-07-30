using System;
using System.Runtime.CompilerServices;
using webApi.src.models;

namespace WebApi.src.presenters
{
    public class PricePresenter
    {
        public long? Id { get; set; }
        public ProductPresenter Product { get; set; }
        public decimal Amount { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }
        public bool IsPromotional { get; set; }
        public PricePresenter()
        {

        }
        public PricePresenter(Price price)
        {
            Id = price.Id;

            if (price.Product != null)
            {
                if(price.Product.Subcategory != null && 
                price.Product.Subcategory.Category != null)
                    price.Product.Subcategory.Category.Subcategories = null;
                Product = new ProductPresenter(price.Product);
            }
            Amount = price.Amount;
            InitialDate = price.InitialDate;
            FinalDate = price.FinalDate;
            IsPromotional = price.IsPromotional;
        }
    }
}