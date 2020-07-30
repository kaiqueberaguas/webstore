using Castle.Core.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using webApi.src.models;

namespace webApi.src.controllers.parameters
{
    public class CategoryParameter
    {
        [Required]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<SubcategoryParameter> Subcategories { get; set; }


        public Category ToModel()
        {
            var category = new Category();
            category.Id = Id;
            category.Name = Name;
            category.Description = Description;
            if (!Subcategories.IsNullOrEmpty())
                Subcategories.ForEach(c => category.Subcategories.Add(c.ToModel()));
            return category;
        }
    }
}
