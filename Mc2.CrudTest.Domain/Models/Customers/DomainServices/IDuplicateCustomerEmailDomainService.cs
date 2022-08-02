using System;
using Mc2.CrudTest.Framework;

namespace Mc2.CrudTest.Domain.Models.Customers.DomainServices
{
    public interface IDuplicateCustomerEmailDomainService : IDomainService
    {
        bool IsEmailExist(string email);

        bool IsEmailExist(int id, string email);
    }
}