using Mc2.CrudTest.Domain.Models.Customers;

namespace Mc2.CrudTest.UnitTests.Customers.TestBuilders
{
    public class FirstNameTestBuilder
    {
        public FirstNameTestBuilder()
        {
            FirstName = "Roya";
        }

        public string FirstName { get; set; }

        public FirstName Build()
        {
            return new FirstName(FirstName);
        }

        public FirstNameTestBuilder WithFirstName(string firstName)
        {
            FirstName = firstName;

            return this;
        }
    }
}