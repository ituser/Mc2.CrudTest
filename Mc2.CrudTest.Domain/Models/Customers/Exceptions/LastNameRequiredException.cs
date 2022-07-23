using Mc2.CrudTest.Framework;

namespace Mc2.CrudTest.Domain.Models.Customers.Exceptions
{
    public class LastNameRequiredException : BusinessException
    {
        public override string Message => "LastName is required!";
    }
}