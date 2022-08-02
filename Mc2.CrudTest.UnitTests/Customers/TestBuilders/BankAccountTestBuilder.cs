using Mc2.CrudTest.Domain.Models.Customers;

namespace Mc2.CrudTest.UnitTests.Customers.TestBuilders
{
    public class BankAccountTestBuilder
    {
        public BankAccountTestBuilder()
        {
            BankAccountNumber = "NL91 ABNA 0417 1643 00";
        }

        public string BankAccountNumber { get; set; }

        public BankAccountNumber Build()
        {
            return new BankAccountNumber(BankAccountNumber);
        }

        public BankAccountTestBuilder WithBankAccountNumber(string bankAccountNumber)
        {
            BankAccountNumber = bankAccountNumber;

            return this;
        }
    }
}