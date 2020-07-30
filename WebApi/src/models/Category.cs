using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webApi.src.models
{
    public class Category : Entity
    {
        public override long? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Subcategory> Subcategories { get; set; }
        public override DateTime? LastModification { get; set; }
        public override DateTime? RegisterDate { get; set; }
    }
}
