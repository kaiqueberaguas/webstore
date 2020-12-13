using System.Collections.Generic;
using Castle.Core.Internal;
using WebApiProdutos.Src.Models;

namespace WebApiProdutos.Src.Presenters
{
    public class CategoryPresenter
    {
        public string Name { get; }
        public long? CategoryCode { get; }
        public string Description { get; }
        public bool IsActive { get; set; }
        public List<SubcategoryPresenter> Subcategories { get; }

        public CategoryPresenter(Category category)
        {
            Name = category.Name;
            CategoryCode = category.Code.GetValueOrDefault();
            IsActive = category.IsActive.GetValueOrDefault();
            Description = category.Description;
            if (!category.Subcategories.IsNullOrEmpty())
            {
                Subcategories = new List<SubcategoryPresenter>();
                category.Subcategories.ForEach(s =>
                {
                    s.Category = null;
                    Subcategories.Add(new SubcategoryPresenter(s));
                });
            }
        }
    }
}