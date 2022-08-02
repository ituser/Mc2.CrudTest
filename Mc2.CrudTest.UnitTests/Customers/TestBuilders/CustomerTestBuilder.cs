using System;
using Mc2.CrudTest.Domain.Models.Customers;
using Mc2.CrudTest.Domain.Models.Customers.DomainServices;
using NSubstitute;

namespace Mc2.CrudTest.UnitTests.Customers.TestBuilders
{
    public class CustomerTestBuilder
    {
        public CustomerTestBuilder()
        {
            FirstName = "Roya";
            LastName = "Allahyari";
            DateOfBirth = DateTime.Parse("1984-04-11");
            Email = "allahyari3631@gmail.com";
            PhoneNumber = "09123491682";
            CountryCode = "IR";
            //BankAccountNumber = "IR75 0560 0826 8000 3876 5720 01";
            BankAccountNumber = "NL91 ABNA 0417 1643 00";

            DuplicateCustomerDomainService = Substitute.For<IDuplicateCustomerDomainService>();
            DuplicateCustomerEmailDomainService = Substitute.For<IDuplicateCustomerEmailDomainService>();
            DuplicateCustomerDomainService.IsCustomerExist(FirstName, LastName, DateOfBirth).Returns(false);
            DuplicateCustomerEmailDomainService.IsEmailExist(Email).Returns(false);
        }

        public IDuplicateCustomerDomainService DuplicateCustomerDomainService { get; set; }

        public IDuplicateCustomerEmailDomainService DuplicateCustomerEmailDomainService { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string CountryCode { get; set; }

        public string BankAccountNumber { get; set; }

        public Customer Build()
        {
            return new Customer(new FirstName(FirstName),
                                new LastName(LastName),
                                DateOfBirth,
                                new PhoneNumber(PhoneNumber, CountryCode),
                                new Email(Email),
                                new BankAccountNumber(BankAccountNumber),
                                DuplicateCustomerDomainService,
                                DuplicateCustomerEmailDomainService);
        }

        public CustomerTestBuilder CustomerWithThisInfoExist()
        {
            DuplicateCustomerDomainService.IsCustomerExist(FirstName, LastName, DateOfBirth).Returns(true);

            return this;
        }

        public CustomerTestBuilder EmailIsExist()
        {
            DuplicateCustomerEmailDomainService.IsEmailExist(Email).Returns(true);

            return this;
        }

        public CustomerTestBuilder WithFirstName(string firstName)
        {
            FirstName = firstName;

            return this;
        }

        public CustomerTestBuilder WithLastName(string lastName)
        {
            LastName = lastName;

            return this;
        }

        public CustomerTestBuilder WithDateOfBirth(DateTime dateOfBirth)
        {
            DateOfBirth = dateOfBirth;

            return this;
        }

        public CustomerTestBuilder WithPhoneNumber(string phoneNumber, string countryCode)
        {
            PhoneNumber = phoneNumber;
            CountryCode = countryCode;

            return this;
        }

        public CustomerTestBuilder WithEmail(string email)
        {
            Email = email;

            return this;
        }

        public CustomerTestBuilder WithBankAccountNumber(string bankAccountNumber)
        {
            BankAccountNumber = bankAccountNumber;

            return this;
        }
    }
}