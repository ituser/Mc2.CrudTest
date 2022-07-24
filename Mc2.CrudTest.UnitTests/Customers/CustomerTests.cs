using System;
using FluentAssertions;
using Mc2.CrudTest.Domain.Models.Customers.Exceptions;
using Xunit;

namespace Mc2.CrudTest.UnitTests.Customers
{
    public class CustomerTests
    {
        public CustomerTests()
        {
            _builder = new CustomerTestBuilder();
        }

        public CustomerTestBuilder _builder { get; set; }

        [Fact]
        public void Should_throw_exception_when_customer_bankAccountNumber_is_invalid()
        {
            Action newCustomer = () => _builder.WithBankAccountNumber("abcd")
                                               .Build();

            newCustomer.Should().Throw<InvalidBankAccountNumberException>();
        }

        [Fact]
        public void Should_throw_exception_when_customer_email_is_invalid()
        {
            Action newCustomer = () => _builder.WithEmail("allahyari3631.com")
                                               .Build();

            newCustomer.Should().Throw<InvalidEmailException>();
        }
        
        [Fact]
        public void Should_throw_exception_when_customer_email_is_exist()
        {
            Action newCustomer = () => _builder.WithEmail("allahyari3631@gmail.com")
                                               .EmailIsExist()
                                               .Build();

            newCustomer.Should().Throw<DuplicateEmailException>();
        }

        [Fact]
        public void Should_throw_exception_when_customer_phoneNumber_is_invalid()
        {
            Action newCustomer = () => _builder.WithPhoneNumber("02144524", "Ch")
                                               .Build();

            newCustomer.Should().Throw<InvalidPhoneNumberException>();
        }

        [Fact]
        public void Should_throw_exception_when_customer_with_FirstName_LastName_DateOfBirth_is_exist()
        {
            Action newCustomer = () => _builder.WithFirstName("Roya")
                                               .WithLastName("Allahyari")
                                               .WithDateOfBirth(DateTime.Parse("1984-04-11"))
                                               .CustomerWithThisInfoExist()
                                               .Build();

            newCustomer.Should().Throw<DuplicateCustomerException>();
        }
    }
}