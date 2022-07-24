using System.Threading;
using System.Threading.Tasks;
using Mc2.CrudTest.Application.Contracts.Customers;
using Mc2.CrudTest.Domain.Models.Customers;
using Mc2.CrudTest.Domain.Models.Customers.DomainServices;
using MediatR;

namespace Mc2.CrudTest.Application.Customers
{
    public class CreateCustomerCommandHandler : AsyncRequestHandler<CreateCustomerCommand>
    {
        private readonly ICustomerRepository customerRepository;

        private readonly IDuplicateCustomerDomainService duplicateCustomerDomainService;

        private readonly IDuplicateCustomerEmailDomainService duplicateCustomerEmailDomainService;

        public CreateCustomerCommandHandler(
            ICustomerRepository repository,
            IDuplicateCustomerDomainService duplicateCustomerDomainService,
            IDuplicateCustomerEmailDomainService duplicateCustomerEmailDomainService)
        {
            this.duplicateCustomerDomainService = duplicateCustomerDomainService;
            this.duplicateCustomerEmailDomainService = duplicateCustomerEmailDomainService;
            customerRepository = repository;
        }

        protected override async Task Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
        {
            var customer = new Customer(new FirstName(command.FirstName),
                                        new LastName(command.LastName),
                                        command.DateOfBirth,
                                        new PhoneNumber(command.PhoneNumber),
                                        new Email(command.Email),
                                        new BankAccountNumber(command.BankAccountNumber),
                                        duplicateCustomerDomainService,
                                        duplicateCustomerEmailDomainService);

           await customerRepository.Create(customer);
        }
    }
}