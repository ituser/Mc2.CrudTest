using Mc2.CrudTest.Domain.Contracts.Events.Customers;
using Mc2.CrudTest.Framework;
using Mc2.CrudTest.QueryModel.Services.Contracts.Customers;

namespace Mc2.CrudTest.QueryModel.Handlers
{
    public class CustomerHandler : ISubscribe
    {
        private readonly ICustomerQueryService customerQueryService;

        public CustomerHandler(ICustomerQueryService customerQueryService)
        {
            this.customerQueryService = customerQueryService;
        }

        public void Handle(CustomerCreatedEvent @event)
        {
            CustomerQueryDTO queryDto = new()
                                        {
                                            Id = @event.Id,
                                            FirstName = @event.FirstName,
                                            LastName = @event.LastName,
                                            DateOfBirth = @event.DateOfBirth,
                                            Email = @event.Email,
                                            CountryCode = @event.CountryCode,
                                            NationalNumber = @event.PhoneNumber,
                                            BankAccountNumber = @event.BankAccountNumber,
                                        };

            customerQueryService.Create(queryDto);
        }

        public void Handle(CustomerModifiedEvent @event)
        {
            CustomerQueryDTO queryDto = new()
                                        {
                                            Id = @event.Id,
                                            FirstName = @event.FirstName,
                                            LastName = @event.LastName,
                                            DateOfBirth = @event.DateOfBirth,
                                            Email = @event.Email,
                                            CountryCode = @event.CountryCode,
                                            NationalNumber = @event.PhoneNumber,
                                            BankAccountNumber = @event.BankAccountNumber,
                                        };

            customerQueryService.Modify(queryDto);
        }

        public void Handle(CustomerRemovedEvent @event)
        {
            customerQueryService.Delete(@event.Id);
        }
    }
}