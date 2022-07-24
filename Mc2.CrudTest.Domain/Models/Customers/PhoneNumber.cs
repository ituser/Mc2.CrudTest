using Mc2.CrudTest.Domain.Models.Customers.Exceptions;
using Mc2.CrudTest.Framework;
using PhoneNumbers;

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
            var phoneUtil = PhoneNumberUtil.GetInstance();

            try
            {
                var phoneNumber = phoneUtil.Parse(phoneNumberStr, countryCode);
                if (phoneUtil.IsValidNumber(phoneNumber))
                {
                    NationalNumber = phoneNumber.NationalNumber;
                    CountryCode = phoneNumber.CountryCode;
                }
            }
            catch
            {
                throw new InvalidPhoneNumberException();
            }
        }
    }
}