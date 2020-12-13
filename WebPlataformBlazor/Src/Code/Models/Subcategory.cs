namespace WebPlataformBlazor.Src.Code.Models
{
    public class Subcategory
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public long SubcategoryCode { get; set; }
        public long CategoryCode { get; set; }
        public int TotalProducts { get; set; }
        public bool? IsActive { get; set; }
    }
}
