using Castle.Core.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using webApi.src.models;

namespace webApi.src.controllers.parameters
{
    public class SubcategoryCreateParameter
    {
        [MaxLength(25)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        [Required]
        public CategoryParameter Category { get; set; }
        public List<ProductParameter> Products { get; set; }

        public Subcategory ToModel()
        {
            var subcategory = new Subcategory();
            subcategory.Name = Name;
            subcategory.Description = Description;
            subcategory.Category = Category.ToModel();
            if (!Products.IsNullOrEmpty())
                Products.ForEach(p => subcategory.Products.Add(p.ToModel()));
            return subcategory;
        }
    }
}
