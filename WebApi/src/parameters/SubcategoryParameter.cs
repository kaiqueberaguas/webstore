using Castle.Core.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using webApi.src.models;

namespace webApi.src.parameters
{
    public class SubcategoryParameter
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CategoryParameter Category { get; set; }
        public List<ProductParameter> Products { get; set; }

        public Subcategory ToModel()
        {
            var subcategory = new Subcategory();
            subcategory.Id = Id;
            subcategory.Name = Name;
            subcategory.Description = Description;
            if(Category != null)subcategory.Category = Category.ToModel();
            if(!Products.IsNullOrEmpty())
                Products.ForEach(p => subcategory.Products.Add(p.ToModel()));
            return subcategory;
        }
    }
}
