using System;
using FluentAssertions;
using Mc2.CrudTest.Domain.Models.Customers.Exceptions;
using Mc2.CrudTest.UnitTests.Customers.TestBuilders;
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
        public void Should_create_customer_with_valid_values()
        {
            var newCustomer = _builder.WithFirstName("Roya")
                                      .WithLastName("Allahyari")
                                      .WithDateOfBirth(DateTime.Parse("1984-04-11"))
                                      .WithPhoneNumber("+989123491682", null)
                                      .WithEmail("allahyari3631@gmail.com")
                                      .WithBankAccountNumber("NL91 ABNA 0417 1643 00")
                                      .Build();

            newCustomer.Should().NotBeNull();
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

        [Fact]
        public void Should_throw_exception_when_customer_email_is_exist()
        {
            Action newCustomer = () => _builder.WithEmail("allahyari3631@gmail.com")
                                               .EmailIsExist()
                                               .Build();

            newCustomer.Should().Throw<DuplicateEmailException>();
        }
    }
}