namespace Bookstore.Business.Core
{
    using Bookstore.DataAccess.Context;
    using System;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Linq.Expressions;
    using Bookstore.DataAccess.Extensions;
    using Bookstore.Infrastructure.Business;
    using Bookstore.Entities.Core;

    public class BusinessCore<TEntity> : IBusinessCore<TEntity>
        where TEntity : EntityCore
    {
        protected readonly BookstoreContext context;
        protected readonly DbSet<TEntity> set;
        protected readonly IQueryable<TEntity> query;
        protected readonly Func<TEntity, TEntity> updateTransformation = x => x;
        protected readonly Func<TEntity, TEntity> createTransformation = x => x;

        public BusinessCore(BookstoreContext context, Func<TEntity, TEntity> updateTransformation = null, Func<TEntity, TEntity> createTransformation = null)
        {
            this.context = context;
            this.set = this.context.Set<TEntity>();
            this.query = this.set.AsQueryable(); // is for set default where
            if (updateTransformation != null) this.updateTransformation = updateTransformation;
            if (createTransformation != null) this.createTransformation = createTransformation;
        }

        #region Queries

        public Task<bool> AnyAsync()
        {
            return this.query.AnyAsync();
        }

        public Task<TEntity> GetAsync(Guid id, string includes = "")
        {
            return this.query
                        .IncludeIncludes(includes)
                        .FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public Task<List<TEntity>> GetAsync(List<Guid> ids, Expression<Func<TEntity, bool>> where = null, Expression<Func<TEntity, bool>> orderBy = null, string includes = "")
        {
            return this.query
                        .IncludeWhere(where)
                        .Where(x => ids.Contains(x.Id))
                        .IncludeOrder(orderBy)
                        .IncludeIncludes(includes)
                        .ToListAsync();
        }

        public Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> where = null, Expression<Func<TEntity, bool>> orderBy = null, string includes = "")
        {
            return this.query
                        .IncludeWhere(where)
                        .IncludeOrder(orderBy)
                        .IncludeIncludes(includes)
                        .ToListAsync();
        }

        #endregion Queries

        #region Commands
        public Task CreateAsync(TEntity entityRaw)
        {
            var entity = this.createTransformation(entityRaw);
            return this.set.AddAsync(entity);
        }

        public Task CreateAsync(List<TEntity> entitiesRaw)
        {
            var entities = entitiesRaw.Select(this.createTransformation);
            return this.set.AddRangeAsync(entities);
        }

        public TEntity Update(TEntity entity)
        {
            return this.set.Update(this.updateTransformation(entity)).Entity;
        }

        public IEnumerable<TEntity> Update(List<TEntity> entitiesRaw)
        {
            var entities = entitiesRaw.Select(this.updateTransformation);
            this.set.UpdateRange(entities);
            return entities;
        }

        public TEntity Remove(TEntity entity)
        {
            return this.set.Remove(entity).Entity;
        }

        public List<TEntity> Remove(List<TEntity> entities)
        {
            this.set.RemoveRange(entities);
            return entities;
        }

        public async Task<TEntity> RemoveAsync(Guid id)
        {
            var entity = await this.GetAsync(id);
            return this.set.Remove(entity).Entity;
        }

        public async Task<List<TEntity>> RemoveAsync(List<Guid> ids)
        {
            var entities = await this.GetAsync(ids);
            this.set.RemoveRange(entities);
            return entities;
        }
        #endregion Commands  


        public Task<int> SaveChangesAsync()
        {
            return this.context.SaveChangesAsync();
        }

    }
}
