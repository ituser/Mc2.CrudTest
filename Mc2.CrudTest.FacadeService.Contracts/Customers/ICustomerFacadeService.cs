using System;
using System.Threading.Tasks;
using Mc2.CrudTest.Application.Contracts.Customers;
using Mc2.CrudTest.Framework;

namespace Mc2.CrudTest.FacadeService.Contracts.Customers
{
    public interface ICustomerFacadeService : IFacadeService
    {
        Task CreateCustomer(CreateCustomerCommand command);

        Task ModifyCustomer(ModifyCustomerCommand command);

        Task RemoveCustomer(Guid customerId);
    }
}