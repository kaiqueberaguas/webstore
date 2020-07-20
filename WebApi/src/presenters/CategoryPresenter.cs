using System;
using webApi.src.models;
using System.Collections.Generic;
using Castle.Core.Internal;

namespace WebApi.src.presenters
{
    public class CategoryPresenter
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<SubcategoryPresenter> Subcategories { get; set; }

        public CategoryPresenter()
        {

        }
        public CategoryPresenter(Category category)
        {
            Id = category.Id;
            Name = category.Name;
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