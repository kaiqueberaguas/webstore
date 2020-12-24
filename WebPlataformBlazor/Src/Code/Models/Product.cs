namespace WebPlataformBlazor.Src.Code.Models
{
    public class Product : BaseModel
    {
        public decimal Price { get; set; }
        public Subcategory Subcategory { get; set; }
     }
}
