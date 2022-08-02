using System;
using FluentAssertions;
using Mc2.CrudTest.Domain.Models.Customers.Exceptions;
using Mc2.CrudTest.Domain.Validators;
using Mc2.CrudTest.UnitTests.Customers.TestBuilders;
using Xunit;

namespace Mc2.CrudTest.UnitTests.Customers
{
    public class PhoneNumberTests
    {
        public PhoneNumberTests()
        {
            _builder = new PhoneNumberTestBuilder();
        }

        public PhoneNumberTestBuilder _builder { get; set; }

        [Theory]
        [InlineData("09123491682", "")]
        [InlineData("", "IR")]
        [InlineData("9123491658254225525222521524582", "IR")]
        [InlineData("09123491682", "98")]
        [InlineData("0989123491682", null)]
        [InlineData("00989123491682", null)]
        [InlineData("+989123498558852252116584582", null)]
        public void Should_throw_exception_when_phoneNumber_is_invalid(string phoneNumber, string countryCode)
        {
            Action newCustomer = () => _builder.WithPhoneNumber(phoneNumber)
                                               .WithCountryCode(countryCode)
                                               .Build();

            newCustomer.Should().Throw<InvalidPhoneNumberException>();
        }

        [Theory]
        [InlineData("+989123491682", null)]
        [InlineData("9123491682", "IR")]
        public void Should_create_phoneNumber_with_valid_value(string phoneNumber, string countryCode)
        {
            var result = _builder.WithPhoneNumber(phoneNumber)
                                 .WithCountryCode(countryCode)
                                 .Build();

            result.Should().NotBeNull();
        }
        
        [Theory]
        [InlineData("+989123491682", true)]
        [InlineData("+31612345678", true)]
        [InlineData("+982188776655", false)]
        public void MobileValidation_WithExpectedResult(string phoneNumber, bool expectedResult)
        {
            bool testResult = MobileValidator.Validate(phoneNumber);
            
            Assert.Equal(testResult, expectedResult);
        }
    }
}