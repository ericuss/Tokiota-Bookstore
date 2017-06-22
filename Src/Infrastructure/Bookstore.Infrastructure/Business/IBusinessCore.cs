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

        Task<List<TEntity>> GetAsync(Guid id, Expression<Func<TEntity, bool>> orderBy = null, string includes = "");

        Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> where = null, Expression<Func<TEntity, bool>> orderBy = null, string includes = "");

        #endregion Queries

        #region Commands
        TEntity CreateAsync(TEntity entityRaw);

        IEnumerable<TEntity> CreateAsync(List<TEntity> entitiesRaw);

        TEntity Update(TEntity entity);

        IEnumerable<TEntity> Update(List<TEntity> entitiesRaw);
        #endregion Commands        

    }
}
