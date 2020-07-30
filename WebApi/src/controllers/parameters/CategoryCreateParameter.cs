using System.ComponentModel.DataAnnotations;
using webApi.src.models;

namespace webApi.src.controllers.parameters
{
    public class CategoryCreateParameter
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        
        public Category ToModel()
        {
            var category = new Category();
            category.Name = Name;
            category.Description = Description;
            return category;
        }
        
    }
}
