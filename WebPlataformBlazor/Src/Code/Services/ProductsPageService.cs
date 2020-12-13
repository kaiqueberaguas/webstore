using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Threading.Tasks;
using WebPlataformBlazor.Src.Code.Models;

namespace WebPlataformBlazor.Src.Code.Services
{
    public class ProductsPageService : PagesService<Product>
    {
        public override string BaseUrl { get; } = "";
        public ProductsPageService(HttpClient httpClient, ILogger<ProductsPageService> logger) : base(httpClient, logger)
        {
        }


        public Task<Pageable<Product>> GetProductsBySubategoryCode(string subcategoryCode, int page, int size)
        {

            return null;
        }


    }
}
