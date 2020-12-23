using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using WebApiProdutos.Src.Interfaces.Repositories;
using WebApiProdutos.Src.Interfaces.Services;
using WebApiProdutos.Src.Models;

namespace WebApiProdutos.Src.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<CategoryService> _logger;

        public CategoryService(ICategoryRepository categoryRepository, ILogger<CategoryService> logger)
        {
            _categoryRepository = categoryRepository;
            _logger = logger;
        }

        public async Task<Category> Get(long code)
        {
            return await _categoryRepository.GetByCode(code);
        }
        public async Task<Pageable<Category>> GetAll(int page, int size)
        {
            return await _categoryRepository.GetAll(page, size);
        }
        public async Task<Category> Create(Category obj)
        {
            return await _categoryRepository.Insert(obj);
        }     

        public async Task<Category> Update(long code, Category obj)
        {
            var result = await _categoryRepository.GetByCode(code);
            if (result is null)
            {
                return result;
            }
            result.Update(obj);
            return await _categoryRepository.Update(result);
            
        }

        public Task<Category> PartialUpdate(long code, Category obj)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Category> Delete(long code)
        {
            var obj = await _categoryRepository.GetByCode(code);
            if (obj != null)
                return await _categoryRepository.Delete(obj.Id.GetValueOrDefault());
            return obj;
        }
    }
}
