using webApi.src.models;
using System.Collections.Generic;
using Castle.Core.Internal;

namespace WebApi.src.presenters
{
    public class CategoryPresenter
    {
        public long? Id { get; }
        public string Name { get;}
        public long CategoryCode { get;}
        public string Description { get;}
        public List<SubcategoryPresenter> Subcategories { get;}

        public CategoryPresenter(Category category)
        {
            Id = category.Id;
            Name = category.Name;
            CategoryCode = category.Code.GetValueOrDefault();
            Description = category.Description;
            Subcategories = new List<SubcategoryPresenter>();
            if(!category.Subcategories.IsNullOrEmpty())
                category.Subcategories.ForEach(s =>
                {
                    s.Category = null;
                    this.Subcategories.Add(new SubcategoryPresenter(s));
                });
        }
    }
}