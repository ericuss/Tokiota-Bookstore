namespace Bookstore.Infrastructure.Business
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Linq.Expressions;
    using Bookstore.Infrastructure.Entity;

    public interface IBusinessCore<TEntity>
        where TEntity : IEntityCore
    {

        #region Queries

        Task<bool> AnyAsync();

        Task<TEntity> GetAsync(Guid id, string includes = "");

        Task<List<TEntity>> GetAsync(List<Guid> ids, Expression<Func<TEntity, bool>> where = null, Expression<Func<TEntity, bool>> orderBy = null, string includes = "");

        Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> where = null, Expression<Func<TEntity, bool>> orderBy = null, string includes = "");

        #endregion Queries

        #region Commands
        Task CreateAsync(TEntity entityRaw);

        Task CreateAsync(List<TEntity> entitiesRaw);

        TEntity Update(TEntity entity);

        IEnumerable<TEntity> Update(List<TEntity> entitiesRaw);

        Task<TEntity> RemoveAsync(Guid id);

        Task<List<TEntity>> RemoveAsync(List<Guid> ids);
        #endregion Commands        

        Task<int> SaveChangesAsync();
    }
}
