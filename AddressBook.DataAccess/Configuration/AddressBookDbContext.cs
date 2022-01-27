using AddressBook.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.DataAccess.Configuration
{
  public class AddressBookDbContext : DbContext
  {
    public AddressBookDbContext()
    {


    }
    public AddressBookDbContext(DbContextOptions<AddressBookDbContext> options)
       : base(options)
    {
    }
    public virtual DbSet<Customer> Customer { get; set; }
    public virtual DbSet<Address> Address { get; set; }
  }
}
