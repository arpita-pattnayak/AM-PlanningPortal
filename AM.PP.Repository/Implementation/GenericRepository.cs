using AM.PP.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AM.PP.Repository.Implementation
{
    /// <summary>
    /// Generic repository implementation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class GenericRepository<T>
        : IGenericRepository<T> where T : class, IEntity
    {
        private readonly ApplicationDBContext _dbContext;


        public GenericRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Get all records 
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>().AsNoTracking();
        }

        /// <summary>
        /// Get all records async
        /// </summary>
        /// <returns></returns>
        public async Task<IList<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>()
                            .AsNoTracking()
                            .ToListAsync();
        }

        /// <summary>
        /// get entity by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T> GetByIdAsync(long id)
        {
            return await _dbContext.Set<T>()
                            .AsNoTracking()
                            .FirstOrDefaultAsync(e => e.Id == id);
        }

        /// <summary>
        /// add entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<int> AddAsync(T entity)
        {
            entity.CreatedOnUtc = DateTime.UtcNow;
            await _dbContext.Set<T>().AddAsync(entity);
            return await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// update entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task UpdateAsync(T entity, long id)
        {
            entity.UpdatedOnUtc = DateTime.UtcNow;
            var curEntity = await _dbContext.Set<T>().FindAsync(id);
            _dbContext.Entry(curEntity).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// delete entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(long id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// delete entity based on condition
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task DeleteAsync(Expression<Func<T, bool>> predicate)
        {
            var entity = await _dbContext.Set<T>().Where(predicate).FirstOrDefaultAsync();
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();

        }

        /// <summary>
        /// get multiple entities based on condition
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<IList<T>> WhereAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().AsNoTracking().Where(predicate).ToListAsync();
        }

        /// <summary>
        /// get the count
        /// </summary>
        /// <returns></returns>
        public async Task<long> CountAsync()
        {
            return await _dbContext.Set<T>().AsNoTracking().CountAsync();
        }

        /// <summary>
        /// get the count based on condition
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<long> CountAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>()
                .AsNoTracking()
                .Where(predicate).CountAsync();
        }


    }
}
