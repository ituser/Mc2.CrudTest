using System;
using System.Threading.Tasks;
using Mc2.CrudTest.Framework;

namespace Mc2.CrudTest.Domain.Models.Customers
{
    public interface ICustomerRepository :IRepository
    {
        Task<Customer> Get(Guid customerId);

        Task Create(Customer customer);

        Task Update(Customer existingCustomer);

        Task Remove(Customer existingCustomer);
    }
}