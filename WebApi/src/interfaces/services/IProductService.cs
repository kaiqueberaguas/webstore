using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApi.src.models;

namespace webApi.src.interfaces.services
{
    public interface IProductService : IBasicCrudService<Product>
    {
    }
}
