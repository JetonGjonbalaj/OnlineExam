using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Interfaces
{
    interface IRepositoryService<TEntity> where TEntity : class
    {
        TEntity Delete(TEntity entityToDelete);
        TEntity Delete(object id);
        ICollection<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, string includeProperties = "", bool noTracking = false);
        Task<ICollection<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, string includeProperties = "", bool noTracking = false);
        TEntity GetById(object id);
        Task<TEntity> GetByIdAsync(object id);
        TEntity Insert(TEntity entity);
        Task<TEntity> InsertAsync(TEntity entity);
        ICollection<TEntity> Insert(ICollection<TEntity> entities);
        Task<ICollection<TEntity>> InsertAsync(ICollection<TEntity> entities);
        TEntity Update(TEntity entity);
        ICollection<TEntity> Update(ICollection<TEntity> entity);
        int Commit();
        Task<int> CommitAsync();
    }
}
