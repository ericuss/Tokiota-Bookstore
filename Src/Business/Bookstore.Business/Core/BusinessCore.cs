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

        public Task<List<TEntity>> GetAsync(Guid id, Expression<Func<TEntity, bool>> orderBy = null, string includes = "")
        {
            return this.query
                        .IncludeWhere(x => x.Id.Equals(id))
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
        public TEntity CreateAsync(TEntity entityRaw)
        {
            var entity = this.createTransformation(entityRaw);
            this.set.AddAsync(entity);
            return entity;
        }

        public IEnumerable<TEntity> CreateAsync(List<TEntity> entitiesRaw)
        {
            var entities = entitiesRaw.Select(this.createTransformation);
            this.set.AddRangeAsync(entities);
            return entities;
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
        #endregion Commands        

    }
}
