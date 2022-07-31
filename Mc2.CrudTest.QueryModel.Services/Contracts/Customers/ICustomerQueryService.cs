using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mc2.CrudTest.QueryModel.Services.Contracts.Customers
{
    public interface ICustomerQueryService
    {
        Task Create(CustomerQueryDTO queryDto);

        Task Modify(CustomerQueryDTO queryDto);

        Task Delete(int customerId);

        Task<CustomerQueryDTO> GetCustomer(int customerId);

        Task<List<CustomerQueryDTO>> GetCustomers();
    }
}