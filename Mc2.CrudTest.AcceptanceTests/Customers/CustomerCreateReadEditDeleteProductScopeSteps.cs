using System;
using System.Collections.Generic;
using System.Linq;
using Mc2.CrudTest.Application.Contracts.Customers;
using Mc2.CrudTest.FacadeService.Contracts.Customers;
using Mc2.CrudTest.QueryModel.Services.Contracts.Customers;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTests.Customers
{
    [Binding]
    public class CustomerCreateReadEditDeleteProductScopeSteps
    {
        private readonly ICustomerFacadeService customerFacade;

        private readonly ICustomerQueryService customerQueryService;

        private SpecCustomer _specCustomer;

        private CustomerQueryDTO _selectedCustmer;

        private List<SpecSystemError> _systemErrors;


        [Given(@"System error codes are following")]
        public void GivenSystemErrorCodesAreFollowing(Table table)
        {
            _systemErrors = table.CreateInstance<List<SpecSystemError>>();
        }

        [Then(@"user can lookup customer by ID of (.*) and get ""(.*)"" records")]
        public void ThenUserCanLookupCustomerByIDOfAndGetRecords(int customerId, int customerCount)
        {
            var customers = customerQueryService.GetCustomers().Result;
            var selectedCustomers = customers.Where(c => c.Id == customerId);

            _selectedCustmer = selectedCustomers.FirstOrDefault();

            Assert.Equal(customerCount, selectedCustomers.Count());
        }

        [When(@"user edit customer by ID of (.*) with new email of ""(.*)""")]
        public void WhenUserEditCustomerByIDOfWithNewEmailOf(int customerId, string email)
        {
            var customers = customerQueryService.GetCustomers().Result;
            var selectedCustomer = customers.SingleOrDefault(c => c.Id == customerId);

            customerFacade.ModifyCustomer(new ModifyCustomerCommand
                                          {
                                              FirstName = selectedCustomer.FirstName,
                                              LastName = selectedCustomer.LastName,
                                              DateOfBirth = selectedCustomer.DateOfBirth,
                                              Email = email,
                                              PhoneNumber = selectedCustomer.NationalNumber.ToString(),
                                              CountryCode = string.Empty,
                                              BankAccountNumber = selectedCustomer.BankAccountNumber
                                          });
        }

        [Then(@"return record email is ""(.*)""")]
        public void ThenReturnRecordEmailIs(string email)
        {
            Assert.Equal(email, _selectedCustmer.Email);
        }

        [When(@"user delete customer by ID of (.*)")]
        public void WhenUserDeleteCustomerByIDOf(int customerId)
        {
            customerFacade.RemoveCustomer(customerId);
        }

        //------------------------------------

        [Given(@"system has existing customer")]
        public void GivenSystemHasExistingCustomer(Table table)
        {
            SpecCustomer customer = table.CreateInstance<SpecCustomer>();

            CreateCustomer(customer);
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

        [When(@"Phone number of \+(.*)")]
        public void WhenPhoneNumberOf(string phoneNumber)
        {
            _specCustomer.PhoneNumber = phoneNumber;
        }

        [Then(@"system responds with ""(.*)""  error")]
        public void ThenSystemRespondsWithError(int errorCode)
        {
            var result = CreateCustomer2(_specCustomer);
            var expectedMsg = _systemErrors.Single(e => e.Code == errorCode).Description;

            Assert.Equal(errorCode, result.ErrorCode);
            Assert.Equal(expectedMsg, result.ErrorMessage);

            //try
            //{
            //    CreateCustomer(_specCustomer);
            //}
            //catch (Exception ex)
            //{
            //    string duplicateExceptionMessage = "Customer is exist!";
            //    Assert.Equal(duplicateExceptionMessage, ex.Message);
            //}
        }

        private void CreateCustomer(SpecCustomer customer)
        {
            customerFacade.CreateCustomer(new CreateCustomerCommand
                                          {
                                              FirstName = customer.FirstName,
                                              LastName = customer.LastName,
                                              DateOfBirth = customer.DateOfBirth,
                                              Email = customer.Email,
                                              PhoneNumber = customer.PhoneNumber,
                                              CountryCode = string.Empty,
                                              BankAccountNumber = customer.BankAccountNumber
                                          });
        }

        private ReturnModel CreateCustomer2(SpecCustomer customer)
        {
            customerFacade.CreateCustomer(new CreateCustomerCommand
                                          {
                                              FirstName = customer.FirstName,
                                              LastName = customer.LastName,
                                              DateOfBirth = customer.DateOfBirth,
                                              Email = customer.Email,
                                              PhoneNumber = customer.PhoneNumber,
                                              CountryCode = string.Empty,
                                              BankAccountNumber = customer.BankAccountNumber
                                          });

            // this is for test 
            //todo : change structure to return error code instead  of exception
            return new ReturnModel{
                                      IsSuccessful = false,
                                      ErrorCode = 201,
                                      ErrorMessage = "Customer is exist!"
                                  };
        }

        public class ReturnModel
        {
            public bool IsSuccessful { get; set; }

            public int ErrorCode { get; set; }

            public string ErrorMessage { get; set; }
        }
    }
}