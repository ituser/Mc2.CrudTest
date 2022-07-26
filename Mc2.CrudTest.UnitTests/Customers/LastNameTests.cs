using System;
using FluentAssertions;
using Mc2.CrudTest.Domain.Models.Customers.Exceptions;
using Mc2.CrudTest.UnitTests.Customers.TestBuilders;
using Xunit;

namespace Mc2.CrudTest.UnitTests.Customers
{
    public class LastNameTests
    {
        public LastNameTests()
        {
            _builder = new LastNameTestBuilder();
        }

        public LastNameTestBuilder _builder { get; set; }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Should_throw_exception_when_lastName_is_invalid(string lastName)
        {
            Action newCustomer = () => _builder.WithLastName(lastName).Build();

            newCustomer.Should().Throw<LastNameRequiredException>();
        }

        [Fact]
        public void Should_create_bankAccountNumber_with_valid_value()
        {
            var lastNameValue = "Allahyari";

            var lastName = _builder.WithLastName(lastNameValue).Build();

            lastName.Should().NotBeNull();
            lastName.Value.Should().Be(lastNameValue);
        }
    }
}