using Mc2.CrudTest.Framework;

namespace Mc2.CrudTest.Domain.Models.Customers.Exceptions
{
    public class InvalidPhoneNumberException : BusinessException
    {
        public override string Message => "Phone number is not valid!";
    }
}