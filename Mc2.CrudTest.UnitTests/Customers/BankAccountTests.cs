using System;
using FluentAssertions;
using Mc2.CrudTest.Domain.Models.Customers.Exceptions;
using Mc2.CrudTest.UnitTests.Customers.TestBuilders;
using Xunit;

namespace Mc2.CrudTest.UnitTests.Customers
{
    public class BankAccountTests
    {
        public BankAccountTests()
        {
            _builder = new BankAccountTestBuilder();
        }

        public BankAccountTestBuilder _builder { get; set; }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Should_throw_exception_when_customer_bankAccountNumber_is_null_or_empty(string bankAccountNumber)
        {
            Action newCustomer = () => _builder.WithBankAccountNumber(bankAccountNumber).Build();

            newCustomer.Should().Throw<BankAccountNumberRequiredException>();
        }

        [Theory]
        [InlineData("IR750560082680003876572001")]
        [InlineData("GB00XXXX11111122222222")]
        [InlineData("abcd")]
        [InlineData("1234567890")]
        public void Should_throw_exception_when_customer_bankAccountNumber_is_invalid(string bankAccountNumber)
        {
            Action newCustomer = () => _builder.WithBankAccountNumber(bankAccountNumber).Build();

            newCustomer.Should().Throw<InvalidBankAccountNumberException>();
        }

        [Theory]
        [InlineData("GB82 WEST 1234 5698 7654 32")]
        [InlineData("NL91 ABNA 0417 1643 00")]
        //[InlineData("IR75 0560 0826 8000 3876 5720 01")]
        public void Should_create_bankAccountNumber_with_valid_value(string bankAccountNumberStr)
        {
            var bankAccountNumber = _builder.WithBankAccountNumber(bankAccountNumberStr).Build();

            bankAccountNumber.Should().NotBeNull();
            bankAccountNumber.Value.Should().Be(bankAccountNumberStr);
        }
    }
}