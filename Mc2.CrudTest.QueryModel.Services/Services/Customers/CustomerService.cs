using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mc2.CrudTest.QueryModel.Models.Models.Customers;
using Mc2.CrudTest.QueryModel.Services.Contracts.Customers;
using Mapster;

namespace Mc2.CrudTest.QueryModel.Services.Services.Customers
{
    public class CustomerQueryService : ICustomerQueryService
    {
        public ICustomerQueryRepository repository;

        public CustomerQueryService(ICustomerQueryRepository customerQueryRepository)
        {
            repository = customerQueryRepository;
        }

        public async Task Create(CustomerQueryDTO queryDto)
        {
            var customer = new CustomerQueryModel
                           {
                               Id = queryDto.Id,
                               FirstName = queryDto.FirstName,
                               LastName = queryDto.LastName,
                               DateOfBirth = queryDto.DateOfBirth,
                               Email = queryDto.Email,
                               CountryCode = queryDto.CountryCode,
                               NationalNumber = queryDto.NationalNumber,
                               BankAccountNumber = queryDto.BankAccountNumber
                           };

            await repository.Create(customer);
        }

        public async Task Modify(CustomerQueryDTO queryDto)
        {
            var existingCustomer = await repository.Get(queryDto.Id);

            existingCustomer.FirstName = queryDto.FirstName;
            existingCustomer.LastName = queryDto.LastName;
            existingCustomer.DateOfBirth = queryDto.DateOfBirth;
            existingCustomer.Email = queryDto.Email;
            existingCustomer.CountryCode = queryDto.CountryCode;
            existingCustomer.NationalNumber = queryDto.NationalNumber;
            existingCustomer.BankAccountNumber = queryDto.BankAccountNumber;

            await repository.Update(existingCustomer);
        }

        public async Task Delete(int customerId)
        {
            var existingCustomer = await repository.Get(customerId);

            await repository.Remove(existingCustomer);
        }

        public async Task<CustomerQueryDTO> GetCustomer(int customerId)
        {
            var customer = await repository.Get(customerId);
            
            return customer.Adapt<CustomerQueryDTO>();
        }

        public async Task<List<CustomerQueryDTO>> GetCustomers()
        {
            var customers = await repository.GetAll();

            return customers.Adapt<List<CustomerQueryDTO>>();
        }
    }
}