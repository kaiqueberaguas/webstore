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
    public class SubcategoryPageService : PagesService<Subcategory>
    {

        public override string BaseUrl { get; } = "https://localhost:5001/api/v1/subcategory";

        public SubcategoryPageService(HttpClient httpClient, ILogger<SubcategoryPageService> logger) : base(httpClient, logger)
        {
        }


        public async Task<Pageable<Subcategory>> GetSubcategorysByCategoryCode(string categoryCode, int page, int size)
        {
            try
            {
                var response = await _httpClient.GetAsync(BaseUrl + $"/category/{categoryCode}?page={page}&size={size}");

                if (response != null && response.StatusCode == HttpStatusCode.OK)
                {
                    var jsonResult = await response.Content.ReadFromJsonAsync<Pageable<Subcategory>>();
                    _logger.LogInformation($"Response : {JsonSerializer.Serialize(jsonResult)}");
                    return jsonResult;
                }
                else
                {
                    _logger.LogWarning($"Erro ao consultar subcategorias, codigo de retorno: {response.StatusCode}");
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
