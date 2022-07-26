using Mc2.CrudTest.QueryModel.Models.Models.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mc2.CrudTest.QueryModel.Date.EFCore.Mappings
{
    public class CustomerMapping
    {
        public class CustomerQueryModelMapping : IEntityTypeConfiguration<CustomerQueryModel>
        {
            public void Configure(EntityTypeBuilder<CustomerQueryModel> builder)
            {
                builder.ToTable("Customers").HasKey(c => c.Id);
                builder.Property(c => c.FirstName).HasMaxLength(256).IsRequired();
                builder.Property(c => c.LastName).HasMaxLength(256).IsRequired();
                builder.Property(c => c.DateOfBirth).IsRequired();
                builder.Property(c => c.Email).HasMaxLength(64).IsRequired();
                builder.Property(c => c.CountryCode).IsRequired();
                builder.Property(c => c.NationalNumber).IsRequired();
                builder.Property(c => c.BankAccountNumber).HasMaxLength(34).IsRequired();
            }
        }
    }
}