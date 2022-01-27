using AddressBook.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.DataAccess.Mapping
{
  public abstract class EntityMap<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : Entity
  {
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {

    }

  }
}
