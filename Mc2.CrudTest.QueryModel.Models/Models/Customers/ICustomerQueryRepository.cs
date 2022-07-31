using System;
using System.Threading.Tasks;

namespace Mc2.CrudTest.QueryModel.Models.Models.Customers
{
    public interface ICustomerQueryRepository 
    {
        Task<CustomerQueryModel> Get(int customerId);

        Task<CustomerQueryModel> GetAll();
        
        Task Create(CustomerQueryModel customer);

        Task Update(CustomerQueryModel customer);

        Task Remove(CustomerQueryModel customer);
    }
}