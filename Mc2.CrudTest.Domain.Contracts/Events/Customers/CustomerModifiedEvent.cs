using System;
using Mc2.CrudTest.Framework;

namespace Mc2.CrudTest.Domain.Contracts.Events.Customers
{
    public record CustomerModifiedEvent(
        Guid Id,
        string FirstName,
        string LastName,
        DateTime DateOfBirth,
        string Email,
        string PhoneNumber,
        string BankAccountNumber,
        DateTime ModifiedDateTime) : DomainEvent
    {
    }
}