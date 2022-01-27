using AddressBook.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AddressBook.DataAccess.Mapping
{
  public class AddressMap : EntityMap<Address>
  {
    public override void Configure(EntityTypeBuilder<Address> builder)
    {
      base.Configure(builder);

      builder.HasKey(x => x.AddressId);
      builder.Property(x => x.AddressId).ValueGeneratedOnAdd();

      builder.Property(x => x.City)
        .IsRequired()
        .HasMaxLength(50);

      builder.Property(x => x.State)
        .IsRequired()
        .HasMaxLength(50);

      builder.Property(x => x.AddressType)
        .IsRequired()
        .HasMaxLength(50);

      builder.Property(x => x.FullAddress)
        .IsRequired()
        .HasMaxLength(200);
    }
  }
}
