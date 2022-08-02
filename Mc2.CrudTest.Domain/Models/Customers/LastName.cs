using Mc2.CrudTest.Domain.Models.Customers.Exceptions;
using Mc2.CrudTest.Framework;

namespace Mc2.CrudTest.Domain.Models.Customers
{
    public class LastName : ValueObject
    {
        public LastName(string value)
        {
            ValidateLastName(value);

            Value = value;
        }

        public string Value { get; set; }

        private static void ValidateLastName(string lastName)
        {
            if (string.IsNullOrEmpty(lastName))
            {
                throw new LastNameRequiredException();
            }
        }
    }
}