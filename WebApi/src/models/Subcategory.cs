using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webApi.src.models
{
    public class Subcategory : Entity
    {
        public override long? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual Category Category { get; set; }
        public long CategoryId { get; set; }
        public List<Product> Products { get; set; }
        public override DateTime? LastModification { get; set; }
        public override DateTime? RegisterDate { get; set; }
    }
}
