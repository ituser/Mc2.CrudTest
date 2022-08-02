using System;
using TechTalk.SpecFlow;

namespace Mc2.CrudTest.AcceptanceTests.Customers
{
    [Binding]
    public class ModifyCustomerFeatureSteps
    {
        [Given(@"I select customer to edit")]
        public void GivenISelectCustomerToEdit()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I set PhoneNumber to '(.*)'")]
        public void GivenISetPhoneNumberTo(Decimal p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I set Email to '(.*)'")]
        public void GivenISetEmailTo(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I set BankAccountNumber to '(.*)'")]
        public void GivenISetBankAccountNumberTo(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        
        [Then(@"customer info should be changed to following values")]
        public void ThenCustomerInfoShouldBeChangedToFollowingValues(Table table)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
