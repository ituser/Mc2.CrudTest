using Mc2.CrudTest.Framework;

namespace Mc2.CrudTest.Domain.Models.Customers.Exceptions
{
    public class DuplicateCustomerException : BusinessException
    {
        public override string Message => "Customer is exist!";
    }
}