using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.DataAccess.Extensions
{
  public static class IncludeExtension
  {
    public static IQueryable<TEntity> IncludeMultiple<TEntity>(this DbSet<TEntity> dbSet, params Expression<Func<TEntity, object>>[] includes) where TEntity : class
    {
      IIncludableQueryable<TEntity, object> query = null;

      if (includes.Length > 0)
      {
        query = dbSet.Include(includes[0]);
      }
      for (int queryIndex = 1; queryIndex < includes.Length; ++queryIndex)
      {
        query = query.Include(includes[queryIndex]);
      }

      return query == null ? dbSet : (IQueryable<TEntity>)query;
    }
  }
}
