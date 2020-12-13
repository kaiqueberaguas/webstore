using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using WebPlataformBlazor.Src.Code.Models;

namespace WebPlataformBlazor.Src.Code.Services
{
    public class CategoryPageService : PagesService<Category>
    {

        public override string BaseUrl { get; } = "https://localhost:5001/api/v1/category";

        public CategoryPageService(HttpClient httpClient, ILogger<CategoryPageService> logger) : base(httpClient, logger)
        {
        }
        public async Task<Pageable<Category>> GetCategories(int page, int size)
        {
            try
            {
                var response = await _httpClient.GetAsync(BaseUrl + $"?page={page}&size={size}");

                if (response != null && response.StatusCode == HttpStatusCode.OK)
                {
                    var jsonResult = await response.Content.ReadFromJsonAsync<Pageable<Category>>();
                    _logger.LogTrace($"Response : {JsonSerializer.Serialize(jsonResult)}");
                    return jsonResult;
                }
                else
                {
                    _logger.LogWarning($"Erro ao consultar Categorias, codigo de retorno: {response.StatusCode}");
                    return null;
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return null;
            }
        }
    }
}
