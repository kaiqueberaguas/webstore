using System.ComponentModel.DataAnnotations;
using WebApiProdutos.Src.Models;

namespace WebApiProdutos.Src.Controllers.Parameters
{
    public class CategoryParameter
    {
        [Required]
        public long CategoryCode { get; set; }

        [MaxLength(25)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        public bool IsActive { get; set; }


        public Category ToModel() => new Category()
        {
            Code = CategoryCode,
            Name = Name,
            IsActive = IsActive,
            Description = Description
        };
    }
}
