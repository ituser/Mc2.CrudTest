using System;
using FluentAssertions;
using Mc2.CrudTest.Domain.Models.Customers.Exceptions;
using Mc2.CrudTest.UnitTests.Customers.TestBuilders;
using Xunit;

namespace Mc2.CrudTest.UnitTests.Customers
{
    public class FirstNameTests
    {
        public FirstNameTests()
        {
            _builder = new FirstNameTestBuilder();
        }

        public FirstNameTestBuilder _builder { get; set; }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Should_throw_exception_when_firstName_is_invalid(string firstName)
        {
            Action newCustomer = () => _builder.WithFirstName(firstName).Build();

            newCustomer.Should().Throw<FirstNameRequiredException>();
        }

        [Fact]
        public void Should_create_bankAccountNumber_with_valid_value()
        {
            var firstNameValue = "Roya";

            var firstName = _builder.WithFirstName(firstNameValue).Build();

            firstName.Should().NotBeNull();
            firstName.Value.Should().Be(firstNameValue);
        }
    }
}