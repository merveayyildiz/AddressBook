using AddressBook.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Entities.Concrete
{
  public class Address : Entity
  {
    public int AddressId { get; set; }
    public int CustomerId { get; set; }
    public string AddressType { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string FullAddress { get; set; }
    public Customer Customer { get; set; }

  }
}
