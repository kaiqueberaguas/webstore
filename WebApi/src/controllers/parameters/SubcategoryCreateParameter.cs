using System.ComponentModel.DataAnnotations;
using webApi.src.models;

namespace webApi.src.controllers.parameters
{
    public class SubcategoryCreateParameter
    {
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
        
        [Required]
        public long CategoryCode { get; set; }

        public Subcategory ToModel()
        {
            var subcategory = new Subcategory();
            subcategory.Name = Name;
            subcategory.Description = Description;
            subcategory.Category = new Category(){Code = this.CategoryCode};
            return subcategory;
        }
    }
}
