using System;
using Mc2.CrudTest.Framework;

namespace Mc2.CrudTest.Domain.Contracts.Events.Customers
{
    public record CustomerModifiedEvent(
        int Id,
        string FirstName,
        string LastName,
        DateTime DateOfBirth,
        string Email,
        ulong PhoneNumber,
        int CountryCode,
        string BankAccountNumber,
        DateTime ModifiedDateTime) : DomainEvent
    {
    }
}