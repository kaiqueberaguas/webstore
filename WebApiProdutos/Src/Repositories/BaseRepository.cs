using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApiProdutos.Src.Dbcontext;
using WebApiProdutos.Src.Interfaces.Repositories;
using WebApiProdutos.Src.Models;

namespace WebApiProdutos.Src.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Entity
    {

        protected readonly StoreContext _storeContext;
        protected readonly ILogger _logger;

        public BaseRepository(StoreContext storeContext, ILogger logger)
        {
            _storeContext = storeContext;
            _logger = logger;
        }

        public void Dispose()
        {
            _storeContext.Dispose();
        }

        public async Task<T> GetByCode(long code)
        {
            try
            {
                return await _storeContext.Set<T>().Where(e => e.Code == code).FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                _logger.LogError(e.StackTrace);
                return null;
            }
        }
        public virtual async Task<T> GetById(long Id)
        {
            try
            {
                return await _storeContext.Set<T>().FindAsync(Id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                _logger.LogError(e.StackTrace);
                return null;
            }
        }
        public virtual async Task<Pageable<T>> GetAll(int page, int size)
        {
            try
            {
                if (page <= 0) page = 1;
                if (size <= 0) size = 1;
                var list = await _storeContext.Set<T>().Skip((page - 1) * size).Take(size).ToListAsync();
                var count = await _storeContext.Set<T>().CountAsync();
                return new Pageable<T>(list, count, page, size);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                _logger.LogError(e.StackTrace);
                return null;
            }
        }
        public virtual async Task<T> Insert(T obj)
        {
            try
            {
                obj.PrepareToCreateRegister();
                _storeContext.Set<T>().Add(obj);
                await _storeContext.SaveChangesAsync();
                return obj;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                _logger.LogError(e.StackTrace);
                return null;
            }
        }
        public virtual async Task<T> Update(T obj)
        {
            try
            {
                obj.UpdateRecorde();
                _storeContext.Entry(obj).State = EntityState.Modified;
                await _storeContext.SaveChangesAsync();
                return obj;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                _logger.LogError(e.StackTrace);
                return null;
            }
        }
        public virtual async Task<T> Delete(long id)
        {
            try
            {
                var obj = _storeContext.Set<T>().Find(id);
                if (obj != null)
                {
                    _storeContext.Set<T>().Remove(obj);
                    await _storeContext.SaveChangesAsync();
                }
                return obj;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                _logger.LogError(e.StackTrace);
                return null;
            }
        }

    }
}
