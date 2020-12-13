using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebPlataformBlazor.Src.Code.Services
{
    public abstract class PagesService<T>
    {
        public virtual string BaseUrl { get; } = "https://localhost:5001";
        protected readonly HttpClient _httpClient;
        protected readonly ILogger<PagesService<T>> _logger;

        protected PagesService(HttpClient httpClient, ILogger<PagesService<T>> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<HttpResponseMessage> Create(T obj)
        {
            try
            {
                _logger.LogInformation("Objeto recebido: " + JsonSerializer.Serialize(obj));
                var response = await _httpClient.PostAsJsonAsync(BaseUrl, obj);
                _logger.LogInformation($"Codigo de retorno da criação de objeto: {response.StatusCode} Mensagem: {response.Content}");
                return response;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return null;
        }

        public async Task<HttpResponseMessage> Delete(string code)
        {
            try
            {
                _logger.LogInformation($"Codigo do objeto recebido para exclusão: {code}");
                var response = await _httpClient.DeleteAsync(BaseUrl + $"/{code}");
                _logger.LogInformation($"Codigo de retorno da exclusão: {response.StatusCode}");
                return response;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return null;
        }

        public async Task<HttpResponseMessage> Update(T obj)
        {
            try
            {
                _logger.LogInformation($"Objecto recebido para atualização: {JsonSerializer.Serialize(obj)}");
                var response = await _httpClient.PutAsJsonAsync(BaseUrl, obj);
                _logger.LogInformation($"Codigo de retorno da tentativa de atualização: {response.StatusCode}");
                return response;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return null;
        }

        //public async Task<HttpResponseMessage> Disable(string code)//implementar no back
        //{
        //    try
        //    {
        //        _logger.LogInformation($"Codigo do objeto a ser desativado: {code}");
        //        var response = await _httpClient.PatchAsync(BaseUrl+$"/disable/{code}",null);
        //        _logger.LogInformation($"Codigo de retorno da tentativa de desativação: {response.StatusCode}");
        //        return response;
        //    }
        //    catch (Exception e)
        //    {
        //        _logger.LogError(e.Message);
        //    }
        //    return null;
        //}
    }
}
