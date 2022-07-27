using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mc2.CrudTest.QueryModel.Services.Contracts.Customers
{
    public interface ICustomerQueryService
    {
        Task Create(CustomerQueryDTO queryDto);

        Task Modify(CustomerQueryDTO queryDto);

        Task Delete(Guid eventId);

        Task<CustomerQueryDTO> GetCustomer(Guid customerId);

        Task<List<CustomerQueryDTO>> GetCustomers();
    }
}