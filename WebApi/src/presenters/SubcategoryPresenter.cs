using System;
using System.Collections.Generic;
using webApi.src.models;

namespace WebApi.src.presenters
{
    public class SubcategoryPresenter
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CategoryPresenter Category { get; set; }

        public SubcategoryPresenter()
        {
            
        }
        
        public SubcategoryPresenter(Subcategory subcategory)
        {
            Id = subcategory.Id;
            Name = subcategory.Name;
            Description = subcategory.Description;
            if (subcategory.Category != null)
            {
                subcategory.Category.Subcategories = null;
                Category = new CategoryPresenter(subcategory.Category);
            }
        }
    }
}