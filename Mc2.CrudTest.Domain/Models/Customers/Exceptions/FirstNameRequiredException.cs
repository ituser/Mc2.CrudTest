using Mc2.CrudTest.Framework;

namespace Mc2.CrudTest.Domain.Models.Customers.Exceptions
{
    public class FirstNameRequiredException : BusinessException
    {
        public override string Message => "FirstName is required!";
    }
}