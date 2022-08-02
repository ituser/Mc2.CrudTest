using Mc2.CrudTest.Framework;

namespace Mc2.CrudTest.Domain.Models.Customers.Exceptions
{
    public class InvalidBankAccountNumberException : BusinessException
    {
        public override string Message => "BankAccountNumber is not valid!";
    }
}