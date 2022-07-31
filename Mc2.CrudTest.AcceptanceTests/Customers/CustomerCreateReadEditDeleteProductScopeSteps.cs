using System;
using Mc2.CrudTest.Domain.Models.Customers;
using Mc2.CrudTest.FacadeService.Contracts.Customers;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTests.Customers
{
    [Binding]
    public class CustomerCreateReadEditDeleteProductScopeSteps
    {
        private readonly ICustomerFacadeService customerFacade;

        private SpecCustomer _specCustomer;

        [Given(@"system has existing customer")]
        public void GivenSystemHasExistingCustomer(Table table)
        {
            var customer = table.CreateInstance<SpecCustomer>();

            Customer.CreateCustomer(customer.FirstName,
                                    customer.LastName,
                                    customer.DateOfBirth,
                                    customer.PhoneNumber,
                                    customer.Email,
                                    customer.BankAccountNumber);
        }

        [When(@"user creates customer with (.*)")]
        public void WhenUserCreatesCustomerWith(string firstName)
        {
            _specCustomer = new SpecCustomer();
            _specCustomer.FirstName = firstName;
        }

        [When(@"lastname of (.*)")]
        public void WhenLastnameOf(string lastName)
        {
            _specCustomer.LastName = lastName;
        }

        [When(@"date of birth of (.*)")]
        public void WhenDateOfBirthOf(DateTime dateOfBirth)
        {
            _specCustomer.DateOfBirth = dateOfBirth;
        }

        [When(@"email of (.*)")]
        public void WhenEmailOf(string email)
        {
            _specCustomer.Email = email;
        }

        [Then(@"system responds with ""(.*)""  error")]
        public void ThenSystemRespondsWithError(int errorCode)
        {
            try
            {
                CreateCustomer(_specCustomer);
            }
            catch (Exception ex)
            {
                var duplicateExceptionMessage = "Customer is exist!";
                Assert.Equal(duplicateExceptionMessage, ex.Message);
            }
        }

        private static Customer CreateCustomer(SpecCustomer customer)
        {
            return Customer.CreateCustomer(customer.FirstName,
                                           customer.LastName,
                                           customer.DateOfBirth,
                                           customer.PhoneNumber,
                                           customer.Email,
                                           customer.BankAccountNumber);

            //var createCustomerCommand = customer.Adapt<CreateCustomerCommand>();
            //customerFacade.CreateCustomer(createCustomerCommand);
        }
    }
}