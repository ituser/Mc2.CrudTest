using System;
using FluentAssertions;
using Mc2.CrudTest.Domain.Models.Customers.Exceptions;
using Mc2.CrudTest.UnitTests.Customers.TestBuilders;
using Xunit;

namespace Mc2.CrudTest.UnitTests.Customers
{
    public class EmailTests
    {
        public EmailTests()
        {
            _builder = new EmailTestBuilder();
        }

        public EmailTestBuilder _builder { get; set; }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Should_throw_exception_when_email__is_null_or_empty(string email)
        {
            Action newCustomer = () => _builder.WithEmail(email).Build();

            newCustomer.Should().Throw<EmailRequiredException>();
        }

        [Theory]
        [InlineData("allahyari3631gmail.com")]
        [InlineData("allahyari3631@gmailcom")]
        [InlineData("@gmail.com")]
        [InlineData("allahyari3631.com")]
        [InlineData("allahyari3631@gmail")]
        [InlineData("allahyari3631")]
        public void Should_throw_exception_when_email_is_invalid(string email)
        {
            Action newCustomer = () => _builder.WithEmail(email).Build();

            newCustomer.Should().Throw<InvalidEmailException>();
        }

        [Fact]
        public void Should_create_bankAccountNumber_with_valid_value()
        {
            var emailValue = "allahyari_3631@yahoo.com";

            var email = _builder.WithEmail(emailValue).Build();

            email.Should().NotBeNull();
            email.Value.Should().Be(emailValue);
        }
    }
}