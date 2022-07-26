using System;
using TechTalk.SpecFlow;

namespace Mc2.CrudTest.AcceptanceTests.Customers
{
    [Binding]
    public class DeleteCustomerFeatureSteps
    {
        [Given(@"There is a customer with following values")]
        public void GivenThereIsACustomerWithFollowingValues(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I select customer to delete")]
        public void GivenISelectCustomerToDelete()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"There is customers with following values")]
        public void GivenThereIsCustomersWithFollowingValues(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I select customer with firstName '(.*)' lastName '(.*)' dateofBirth '(.*)' to edit")]
        public void GivenISelectCustomerWithFirstNameLastNameDateofBirthToEdit(string p0, string p1, string p2)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I set firstName to '(.*)'")]
        public void GivenISetFirstNameTo(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I set lastName to '(.*)'")]
        public void GivenISetLastNameTo(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I set DateOfBirth to '(.*)'")]
        public void GivenISetDateOfBirthTo(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I select customer with firstName '(.*)' lastName '(.*)' dateofBirth '(.*)' to edit")]
        public void WhenISelectCustomerWithFirstNameLastNameDateofBirthToEdit(string p0, string p1, string p2)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I set firstName to '(.*)'")]
        public void WhenISetFirstNameTo(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I set lastName to '(.*)'")]
        public void WhenISetLastNameTo(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I set DateOfBirth to '(.*)'")]
        public void WhenISetDateOfBirthTo(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"The customer should removed from customers list")]
        public void ThenTheCustomerShouldRemovedFromCustomersList()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I select customer with firstName '(.*)' lastName '(.*)' dateofBirth '(.*)' to delete")]
        public void ThenISelectCustomerWithFirstNameLastNameDateofBirthToDelete(string p0, string p1, string p2)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I press Submit button")]
        public void ThenIPressSubmitButton()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
