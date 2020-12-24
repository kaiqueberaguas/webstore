using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using WebPlataformBlazor.Src.Code.Interfaces;
using WebPlataformBlazor.Src.Code.Models;

namespace WebPlataformBlazor.Src.Code.Services
{
    public abstract class PagesService<T> : IBasicCrudService<T> where T : BaseModel
    {
        public virtual string BaseUrl { get; } = "https://localhost:5001";

        protected readonly HttpClient _httpClient;
        protected readonly ILogger<PagesService<T>> _logger;
        //private readonly IConfiguration _configuration { get; set; }

        protected PagesService(HttpClient httpClient, ILogger<PagesService<T>> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public Task<Pageable<T>> GetAll(int page, int size)
        {
            throw new NotImplementedException();
        }

        public Task<T> Get(long code)
        {
            throw new NotImplementedException();
        }

        public Task<T> Update(long code, T obj)
        {
            throw new NotImplementedException();
        }

        public async Task<T> Create(T obj)
        {
            
            try
            {
                //_logger.LogInformation("Objeto recebido: " + JsonSerializer.Serialize(obj));
                using var response = await _httpClient.PostAsJsonAsync(BaseUrl, obj);
                //_logger.LogInformation($"Codigo de retorno da criação de objeto: {response.StatusCode} Mensagem: {response.Content}");
                return response.Content as T;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return null;
        }

        public Task<T> Delete(long code)
        {
            throw new NotImplementedException();
        }

        //public Task<T> Delete(long code)
        //{
        //    throw new NotImplementedException();
        //}

        //public virtual async Task<HttpResponseMessage> Delete(string code)
        //{
        //    try
        //    {
        //        _logger.LogInformation($"Codigo do objeto recebido para exclusão: {code}");
        //        var response = await _httpClient.DeleteAsync(BaseUrl + $"/{code}");
        //        _logger.LogInformation($"Codigo de retorno da exclusão: {response.StatusCode}");
        //        return response;
        //    }
        //    catch (Exception e)
        //    {
        //        _logger.LogError(e.Message);
        //    }
        //    return null;
        //}
        //public virtual async Task<HttpResponseMessage> Update(long code, T obj)
        //{
        //    try
        //    {
        //        _logger.LogInformation($"Objecto recebido para atualização: {JsonSerializer.Serialize(obj)}");
        //        var response = await _httpClient.PutAsJsonAsync(BaseUrl, obj);
        //        _logger.LogInformation($"Codigo de retorno da tentativa de atualização: {response.StatusCode}");
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
