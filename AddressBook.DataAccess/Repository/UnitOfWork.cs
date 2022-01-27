using AddressBook.DataAccess.Configuration;
using AddressBook.DataAccess.Extensions;
using AddressBook.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.DataAccess.Repository
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly AddressBookDbContext _dbContext;
    public UnitOfWork(AddressBookDbContext dbContext)
    {
      _dbContext = dbContext;
    }
    public T Add<T>(T entity) where T : Entity
    {
      _dbContext.Add(entity);
      return entity;
    }

    public IQueryable<T> All<T>() where T : Entity
    {
      return Query<T>();
    }

    public bool Delete<T>(T entity) where T : Entity
    {
      _dbContext.Remove(entity);

      return true;
    }

    public T FirstOrDefault<T>(Expression<Func<T, bool>> where) where T : Entity
    {
      return Query<T>().FirstOrDefault(where);
    }

    public DbSet<T> Query<T>() where T : Entity
    {
      return _dbContext.Set<T>();
    }

    public void Save()
    {
      _dbContext.SaveChanges();
    }

    public bool Update<T>(T entity) where T : Entity
    {
      _dbContext.Update(entity);

      return true;
    }

    public IQueryable<T> Where<T>(Expression<Func<T, bool>> where) where T : Entity
    {
      return Query<T>().Where(where);
    }

    public IQueryable<T> WhereInclude<T>(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes) where T : Entity
    {
      return Query<T>().IncludeMultiple(includes).Where(where);
    }
  }
}
