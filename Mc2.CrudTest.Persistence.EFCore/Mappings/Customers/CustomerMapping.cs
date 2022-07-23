using Mc2.CrudTest.Domain.Models.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mc2.CrudTest.Persistence.EFCore.Mappings.Customers
{
    public class CustomerMapping : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable($"{nameof(Customer)}s").HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.OwnsOne(x => x.FirstName,
                            map =>
                            {
                                map.Property(p => p.Value).HasColumnName(nameof(Customer.FirstName))
                                   .IsRequired()
                                   .HasMaxLength(256);
                            });
            builder.OwnsOne(x => x.LastName,
                            map =>
                            {
                                map.Property(p => p.Value).HasColumnName(nameof(Customer.LastName))
                                   .IsRequired()
                                   .HasMaxLength(256);
                            });
            builder.Property(x => x.DateOfBirth);
            builder.OwnsOne(x => x.Email,
                            map =>
                            {
                                map.Property(p => p.Value).HasColumnName(nameof(Customer.Email))
                                   .IsRequired()
                                   .HasMaxLength(64);
                            });
            builder.OwnsOne(x => x.PhoneNumber,
                            map =>
                            {
                                map.Property(p => p.Value).HasColumnName(nameof(Customer.PhoneNumber))
                                   .IsRequired()
                                   .HasMaxLength(15);
                            });
            builder.OwnsOne(x => x.BankAccountNumber,
                            map =>
                            {
                                map.Property(p => p.Value).HasColumnName(nameof(Customer.BankAccountNumber))
                                   .IsRequired()
                                   .HasMaxLength(34);
                            });
        }
    }
}