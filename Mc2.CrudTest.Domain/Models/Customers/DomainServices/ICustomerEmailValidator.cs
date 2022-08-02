namespace Mc2.CrudTest.Domain.Models.Customers.DomainServices
{
    public interface ICustomerEmailValidator
    {
        bool Validate(string value);
    }
}