using System;

namespace Mc2.CrudTest.QueryModel.Services.Contracts.Customers
{
    public class CustomerQueryDTO
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }

        public int CountryCode { get; set; }

        public ulong NationalNumber { get; set; }

        public string BankAccountNumber { get; set; }
    }
}