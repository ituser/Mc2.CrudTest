using Mc2.CrudTest.Framework;

namespace Mc2.CrudTest.Domain.Models.Customers.Exceptions
{
    public class InvalidEmailException : BusinessException
    {
        public override string Message => "Email is not valid!";
    }
}