using System.Collections.Generic;

namespace WebPlataformBlazor.Src.Code.Models
{
    public class Pageable<T> where T : BaseModel
    {
        public List<T> Content { get; set; } = new List<T>();
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }

    }

}
