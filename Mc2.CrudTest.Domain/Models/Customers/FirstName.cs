using Mc2.CrudTest.Domain.Models.Customers.Exceptions;
using Mc2.CrudTest.Framework;

namespace Mc2.CrudTest.Domain.Models.Customers
{
    public class FirstName : ValueObject
    {
        public FirstName(string value)
        {
            ValidateFirstName(value);

            Value = value;
        }

        public string Value { get; set; }

        private static void ValidateFirstName(string firstName)
        {
            if (string.IsNullOrEmpty(firstName))
            {
                throw new FirstNameRequiredException();
            }
        }
    }
}