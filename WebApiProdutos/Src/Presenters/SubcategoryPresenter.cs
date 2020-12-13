using WebApiProdutos.Src.Models;

namespace WebApiProdutos.Src.Presenters
{
    public class SubcategoryPresenter
    {
        public string Name { get; }
        public string Description { get; }
        public long SubcatedoryCode { get; }
        public bool IsActive { get; set; }

        public SubcategoryPresenter(Subcategory subcategory)
        {
            Name = subcategory.Name;
            SubcatedoryCode = subcategory.Code.GetValueOrDefault();
            Description = subcategory.Description;
            IsActive = subcategory.IsActive.GetValueOrDefault();
        }
    }
}