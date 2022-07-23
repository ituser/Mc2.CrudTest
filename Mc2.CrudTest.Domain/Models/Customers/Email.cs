using Mc2.CrudTest.Domain.Models.Customers.Exceptions;
using Mc2.CrudTest.Framework;

namespace Mc2.CrudTest.Domain.Models.Customers
{
    public class Email : ValueObject
    {
        public Email(string value)
        {
            ValidateEmail(value);

            Value = value;
        }

        public string Value { get; set; }

        private static void ValidateEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new EmailRequiredException();
            }

            if (!IsEmailFormatValid(email))
            {
                throw new InvalidEmailException();
            }
        }

        private static bool IsEmailFormatValid(string email)
        {
            return true;
        }
    }
}