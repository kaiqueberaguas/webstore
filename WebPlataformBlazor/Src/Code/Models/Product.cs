namespace WebPlataformBlazor.Src.Code.Models
{
    public class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProductCode { get; set; }
        public decimal Price { get; set; }
        public Subcategory Subcategory { get; set; }
        public bool? IsActive { get; set; }
    }
}
