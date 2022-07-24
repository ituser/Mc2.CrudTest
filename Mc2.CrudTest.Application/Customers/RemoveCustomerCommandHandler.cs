using System.Threading;
using System.Threading.Tasks;
using Mc2.CrudTest.Application.Contracts.Customers;
using Mc2.CrudTest.Domain.Models.Customers;
using MediatR;

namespace Mc2.CrudTest.Application.Customers
{
    public class RemoveCustomerCommandHandler : AsyncRequestHandler<RemoveCustomerCommand>
    {
        private readonly ICustomerRepository customerRepository;

        public RemoveCustomerCommandHandler(ICustomerRepository repository)
        {
            customerRepository = repository;
        }

        protected override async Task Handle(RemoveCustomerCommand command, CancellationToken cancellationToken)
        {
            var existingCustomer = await customerRepository.Get(command.Id);

            await customerRepository.Remove(existingCustomer);
        }
    }
}