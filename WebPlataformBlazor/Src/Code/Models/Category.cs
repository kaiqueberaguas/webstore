namespace WebPlataformBlazor.Src.Code.Models
{
    public class Category
    {
        public string Name { get; set; }
        public long? CategoryCode { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public int TotalSubcategorys { get; set; }

        public override string ToString()
        {
            return Name + " - " + Description;
        }

    }
}
