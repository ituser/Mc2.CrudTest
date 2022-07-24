using System;
using MediatR;

namespace Mc2.CrudTest.Application.Contracts.Customers
{
    public class ModifyCustomerCommand : IRequest
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string BankAccountNumber { get; set; }
    }
}