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
        
        [MaxLength(25)]
        public string Name { get; set; }
        
        [MaxLength(100)]
        public string Description { get; set; }


        public Category ToModel()
        {
            var category = new Category();
            category.Id = Id;
            category.Name = Name;
            category.Description = Description;
            return category;
        }
    }
}
