using System;
using webApi.src.models;

namespace WebApi.src.presenters
{
    public class ProductPresenter
    {
        public long? Id { get; }
        public string Name { get; }
        public long ProductCode { get; }
        public string Description { get; }
        public string Information { get; }
        public SubcategoryPresenter Subcategory { get; }
        public long AvailableQuantity { get; }
        public DateTime LimitDate { get; }

        public ProductPresenter(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            ProductCode = product.Code.GetValueOrDefault();
            Description = product.Description;
            Information = product.Information;
            if (product.Subcategory != null)
            {
                Subcategory = prepareSimpleSearch(product.Subcategory);
            }
            AvailableQuantity = product.AvailableQuantity.Value;
            LimitDate = product.LimitDate;
        }

        private SubcategoryPresenter prepareSimpleSearch(Subcategory subcategory)
        {
            var model = new Subcategory()
            {
                Name = subcategory.Name,
                Code = subcategory.Code.GetValueOrDefault()
            };
            return new SubcategoryPresenter(model);
        }
    }
}