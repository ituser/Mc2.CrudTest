using Mc2.CrudTest.Domain.Models.Customers;

namespace Mc2.CrudTest.UnitTests.Customers.TestBuilders
{
    public class LastNameTestBuilder
    {
        public LastNameTestBuilder()
        {
            LastName = "Allahyari";
        }

        public string LastName { get; set; }

        public LastName Build()
        {
            return new LastName(LastName);
        }

        public LastNameTestBuilder WithLastName(string lastName)
        {
            LastName = lastName;

            return this;
        }
    }
}