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
  public interface IUnitOfWork
  {
    DbSet<T> Query<T>() where T : Entity;

    T Add<T>(T entity) where T : Entity;

    bool Update<T>(T entity) where T : Entity;

    bool Delete<T>(T entity) where T : Entity;

    void Save();

    IQueryable<T> All<T>() where T : Entity;

    T FirstOrDefault<T>(Expression<Func<T, bool>> where) where T : Entity;

    IQueryable<T> Where<T>(Expression<Func<T, bool>> where) where T : Entity;

    IQueryable<T> WhereInclude<T>(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes) where T : Entity;
  }
}
