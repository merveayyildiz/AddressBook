using AddressBook.Entities.Base;
using System.Collections.Generic;

namespace AddressBook.Entities.Concrete
{
  public class Customer : Entity
  {
    public int CustomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public ICollection<Address> Addresses { get; set; }
  }
}
