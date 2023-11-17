using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AM.PP.Repository.Interface
{
    public interface IGenericRepository<T> where T : class, IEntity
    {
        /// <summary>
        /// List<DeadletterMessage>
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Get all records async
        /// </summary>
        /// <returns></returns>
        Task<IList<T>> GetAllAsync();

        /// <summary>
        /// get entity by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(long id);

        /// <summary>
        /// add entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> AddAsync(T entity);

        /// <summary>
        /// update entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task UpdateAsync(T entity, long id);

        /// <summary>
        /// delete entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(long id);

        /// <summary>
        /// delete entity based on condition
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task DeleteAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// get multiple entities based on condition
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<IList<T>> WhereAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// get the count
        /// </summary>
        /// <returns></returns>
        Task<long> CountAsync();

        /// <summary>
        /// get the count based on condition
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<long> CountAsync(Expression<Func<T, bool>> predicate);


    }
}
