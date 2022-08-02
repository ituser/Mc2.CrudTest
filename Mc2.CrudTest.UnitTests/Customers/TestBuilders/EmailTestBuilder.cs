using Mc2.CrudTest.Domain.Models.Customers;

namespace Mc2.CrudTest.UnitTests.Customers.TestBuilders
{
    public class EmailTestBuilder
    {
        public EmailTestBuilder()
        {
            Email = "allahyari3631@gmail.com";
        }

        public string Email { get; set; }

        public Email Build()
        {
            return new Email(Email);
        }

        public EmailTestBuilder WithEmail(string email)
        {
            Email = email;

            return this;
        }
    }
}