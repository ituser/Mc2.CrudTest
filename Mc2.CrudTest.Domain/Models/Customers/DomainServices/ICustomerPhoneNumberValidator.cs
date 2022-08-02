namespace Mc2.CrudTest.Domain.Models.Customers.DomainServices
{
    public interface ICustomerPhoneNumberValidator
    {
        bool Validate(string value);
    }
}