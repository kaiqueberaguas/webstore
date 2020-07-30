
using System;
using webApi.src.models;

namespace WebApi.src.presenters
{
    public class ProductPresenter
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Information { get; set; }
        public SubcategoryPresenter Subcategory { get; set; }
        public long AvailableQuantity { get; set; }
        public DateTime LimitDate { get; set; }

        public ProductPresenter()
        {

        }
        public ProductPresenter(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Description = product.Description;
            Information = product.Information;
            if (product.Subcategory != null)
            {
                if (product.Subcategory.Category != null)
                    product.Subcategory.Category.Subcategories = null;
                Subcategory = new SubcategoryPresenter(product.Subcategory);
            }
            AvailableQuantity = product.AvailableQuantity;
            LimitDate = product.LimitDate;
        }
    }
}