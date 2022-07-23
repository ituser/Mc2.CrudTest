using System;
using Mc2.CrudTest.Framework;

namespace Mc2.CrudTest.Domain.Models.Customers.DomainServices
{
    public interface IDuplicateCustomerDomainService : IDomainService
    {
        bool IsCustomerExist(string firstName, string lastName, DateTime dateOfBirth);

        bool IsCustomerExist(Guid id, string firstName, string lastName, DateTime dateOfBirth);
    }
}