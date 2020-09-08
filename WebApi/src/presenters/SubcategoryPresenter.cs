using webApi.src.models;

namespace WebApi.src.presenters
{
    public class SubcategoryPresenter
    {
        public long? Id { get; }
        public string Name { get; }
        public string Description { get; }
        public long SubcatedoryCode { get; }
        public CategoryPresenter Category { get; }

        public SubcategoryPresenter(Subcategory subcategory)
        {
            Id = subcategory.Id;
            Name = subcategory.Name;
            SubcatedoryCode = subcategory.Code.GetValueOrDefault();
            Description = subcategory.Description;
            if (subcategory.Category != null)
            {
                Category = prepateSimpleSearch(subcategory.Category);
            }
        }

        private CategoryPresenter prepateSimpleSearch(Category category)
        {
            var model = new Category()
            {
                Code = category.Code.GetValueOrDefault(),
                Name = category.Name
            };
            return new CategoryPresenter(model);
        }
    }
}