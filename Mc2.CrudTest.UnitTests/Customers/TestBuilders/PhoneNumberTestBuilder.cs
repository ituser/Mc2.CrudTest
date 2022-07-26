using Mc2.CrudTest.Domain.Models.Customers;

namespace Mc2.CrudTest.UnitTests.Customers.TestBuilders
{
    public class PhoneNumberTestBuilder
    {
        public PhoneNumberTestBuilder()
        {
            CountryCode = "IR";
            PhoneNumber = "09123491682";
        }

        public string CountryCode { get; set; }

        public string PhoneNumber { get; set; }


        public PhoneNumber Build()
        {
            return new PhoneNumber(PhoneNumber, CountryCode);
        }

        public PhoneNumberTestBuilder WithCountryCode(string countryCode)
        {
            CountryCode = countryCode;

            return this;
        }

        public PhoneNumberTestBuilder WithPhoneNumber(string phoneNumber)
        {
            PhoneNumber = phoneNumber;

            return this;
        }
    }
}