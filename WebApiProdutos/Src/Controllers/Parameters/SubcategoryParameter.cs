using System.ComponentModel.DataAnnotations;
using WebApiProdutos.Src.Models;

namespace WebApiProdutos.Src.Controllers.Parameters
{
    public class SubcategoryParameter
    {
        [Required]
        public long SubcategoryCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long CategoryCode { get; set; }
        public bool IsActive { get; set; }

        public Subcategory ToModel() => new Subcategory()
        {
            Code = SubcategoryCode,
            Name = Name,
            Description = Description,
            Category = new Category() { Code = CategoryCode },
        };
    }
}
