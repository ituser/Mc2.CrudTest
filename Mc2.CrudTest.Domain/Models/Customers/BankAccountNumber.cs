using IbanNet;
using IbanNet.Registry;
using Mc2.CrudTest.Domain.Models.Customers.Exceptions;
using Mc2.CrudTest.Framework;

namespace Mc2.CrudTest.Domain.Models.Customers
{
    public class BankAccountNumber : ValueObject
    {
        public BankAccountNumber(string value)
        {
            ValidateBankAccountNumber(value);

            Value = value;
        }

        public string Value { get; set; }

        private static void ValidateBankAccountNumber(string bankAccountNumber)
        {
            if (string.IsNullOrEmpty(bankAccountNumber))
            {
                throw new BankAccountNumberRequiredException();
            }

            if (!IsValidBankAccountNumber(bankAccountNumber))
            {
                throw new InvalidBankAccountNumberException();
            }
        }

        private static bool IsValidBankAccountNumber(string bankAccountNumber)
        {
            var parser = new IbanParser(IbanRegistry.Default);

            return parser.TryParse(bankAccountNumber, out Iban _);
        }
    }
}