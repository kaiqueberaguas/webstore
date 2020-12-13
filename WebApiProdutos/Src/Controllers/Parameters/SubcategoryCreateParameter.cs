using System.ComponentModel.DataAnnotations;
using WebApiProdutos.Src.Models;

namespace WebApiProdutos.Src.Controllers.Parameters
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

        public Subcategory ToModel() => new Subcategory()
        {
            Name = Name,
            Description = Description,
            Category = new Category() { Code = CategoryCode }
        };
    }
}
