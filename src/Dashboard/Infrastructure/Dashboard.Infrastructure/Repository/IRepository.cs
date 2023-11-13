using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Infrastructure.Repository
{
    /// <summary>
    /// Базовый репозиторий.
    /// </summary>
    /// <typeparam name="TEntity">Туп сущности.</typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicat"></param>
        /// <returns></returns>
        IQueryable<TEntity> GetAllFiltered(Expression<Func<TEntity, bool>> predicat);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task AddAsync(TEntity model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task UpdateAsync(TEntity model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task DeleteAsync(TEntity model);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task SaveChangesAsync();
    }
}
