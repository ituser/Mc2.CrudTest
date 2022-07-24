using System;
using System.Threading.Tasks;
using Mc2.CrudTest.Application.Contracts.Customers;
using Mc2.CrudTest.FacadeService.Contracts.Customers;
using MediatR;

namespace Mc2.CrudTest.FacadeService.Customers
{
    public class CustomerFacadeService : ICustomerFacadeService
    {
        private readonly IMediator mediator;

        public CustomerFacadeService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task CreateCustomer(CreateCustomerCommand command)
        {
            await mediator.Send(command);
        }

        public async Task ModifyCustomer(ModifyCustomerCommand command)
        {
            await mediator.Send(command);
        }

        public async Task RemoveCustomer(Guid customerId)
        {
            await mediator.Send(new RemoveCustomerCommand
                                {
                                    Id = customerId
                                });
        }
    }
}