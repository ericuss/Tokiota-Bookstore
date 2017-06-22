namespace Bookstore.DataAccess.Extensions
{
    using Bookstore.Entities.Core;
    using Bookstore.Infrastructure.Entity;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public static class ContextExtensions
    {
        public static IQueryable<TEntity> IncludeWhere<TEntity>(this IQueryable<TEntity> query, Expression<Func<TEntity, bool>> where) where TEntity : IEntityCore
        {
            if (where != null) query = query.Where(where);
            return query;
        }

        public static IQueryable<TEntity> IncludeOrder<TEntity>(this IQueryable<TEntity> query, Expression<Func<TEntity, bool>> orderBy) where TEntity : IEntityCore
        {
            if (orderBy != null) query = query.OrderBy(orderBy);
            return query;
        }

        public static IQueryable<TEntity> IncludeIncludes<TEntity>(this IQueryable<TEntity> query, string includes) where TEntity : EntityCore
        {
            if (!string.IsNullOrWhiteSpace(includes)) query = query.Include(includes);
            return query;
        }
    }
}
