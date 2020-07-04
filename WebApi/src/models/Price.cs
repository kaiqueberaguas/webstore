using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webApi.src.models
{
    public class Price
    {
        public long Id { get; set; }
        public Product Product { get; set; }
        public double Amount { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }
        public bool IsPromotional { get; set; }
        public string LastModification { get; set; }
        public string OriginRegister { get; set; }

    }
}
