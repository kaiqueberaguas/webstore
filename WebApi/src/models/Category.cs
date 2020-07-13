using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webApi.src.models
{
    public class Category
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Subcategory> Subcategories { get; set; }
        public DateTime LastModification { get; set; }
        public DateTime RegisterDate { get; set; }
        public string OriginRegister { get; set; }
    }
}
