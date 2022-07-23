using Mc2.CrudTest.Framework;

namespace Mc2.CrudTest.Domain.Models.Customers.Exceptions
{
    public class PhoneNumberRequiredException : BusinessException
    {
        public override string Message => "PhoneNumber is required!";
    }
}