using Mc2.CrudTest.Domain.Models.Customers.Exceptions;
using Mc2.CrudTest.Framework;

namespace Mc2.CrudTest.Domain.Models.Customers
{
    public class PhoneNumber : ValueObject
    {
        public PhoneNumber(string value)
        {
            ValidatePhoneNumber(value);

            Value = value;
        }

        public string Value { get; set; }

        private static void ValidatePhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
            {
                throw new PhoneNumberRequiredException();
            }

            if (!IsPhoneNumberFormatValid(phoneNumber))
            {
                throw new InvalidPhoneNumberException();
            }
        }

        private static bool IsPhoneNumberFormatValid(string phoneNumber)
        {
            return true;
        }
    }
}