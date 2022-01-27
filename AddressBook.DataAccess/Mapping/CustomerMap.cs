using AddressBook.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AddressBook.DataAccess.Mapping
{
  public class CustomerMap : EntityMap<Customer>
  {
    public override void Configure(EntityTypeBuilder<Customer> builder)
    {
      base.Configure(builder);

      builder.HasKey(x => x.CustomerId);
      builder.Property(x => x.CustomerId).ValueGeneratedOnAdd();

      builder.Property(x => x.FirstName)
        .IsRequired()
        .HasMaxLength(100);

      builder.Property(x => x.LastName)
        .IsRequired()
        .HasMaxLength(100);
    }
  }
}
