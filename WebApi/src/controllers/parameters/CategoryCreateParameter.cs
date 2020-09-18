using System.ComponentModel.DataAnnotations;
using webApi.src.models;

namespace webApi.src.controllers.parameters
{
    public class CategoryCreateParameter
    {
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
        
        
        public Category ToModel() => new Category() { Name = Name, Description = Description }; 
    }
}
