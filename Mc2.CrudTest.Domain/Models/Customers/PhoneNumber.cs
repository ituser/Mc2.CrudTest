using Mc2.CrudTest.Domain.Models.Customers.Exceptions;
using Mc2.CrudTest.Domain.Validators;
using Mc2.CrudTest.Framework;
using PhoneNumberUtil = PhoneNumbers.PhoneNumber;

namespace Mc2.CrudTest.Domain.Models.Customers
{
    public class PhoneNumber : ValueObject
    {
        public PhoneNumber(string phoneNumber, string countryCode)
        {
            SetPhoneNumber(phoneNumber, countryCode);
        }

        private PhoneNumber()
        {
        }

        public int CountryCode { get; set; }

        public ulong NationalNumber { get; set; }

        private void SetPhoneNumber(string phoneNumberStr, string countryCode)
        {
            if (!MobileValidator.TryParse(phoneNumberStr, out PhoneNumberUtil phoneNumber))
            {
                throw new InvalidPhoneNumberException();
            }
            
            CountryCode = phoneNumber.CountryCode;
            NationalNumber = phoneNumber.NationalNumber;
        }
    }
}