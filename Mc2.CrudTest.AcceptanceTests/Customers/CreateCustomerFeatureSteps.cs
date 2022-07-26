using System;
using TechTalk.SpecFlow;

namespace Mc2.CrudTest.AcceptanceTests.Customers
{
    [Binding]
    public class CreateCustomerFeatureSteps
    {
        [Given(@"I enter following values for new customer")]
        public void GivenIEnterFollowingValuesForNewCustomer(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"There is a customer by values FirstName '(.*)', LastName '(.*)', DateOfBirth '(.*)'")]
        public void GivenThereIsACustomerByValuesFirstNameLastNameDateOfBirth(string p0, string p1, string p2)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I enter Roya and Allahyari and (.*)(.*) and \+(.*) and allahyari(.*)@gmail\.com and FR(.*) (.*) (.*) (.*)")]
        public void GivenIEnterRoyaAndAllahyariAndAndAndAllahyariGmail_ComAndFR(string p0, int p1, Decimal p2, int p3, string p4, string p5, string p6, int p7)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I press Submit button")]
        public void WhenIPressSubmitButton()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I should not get any exception")]
        public void ThenIShouldNotGetAnyException()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I should get '(.*)' exception")]
        public void ThenIShouldGetException(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"successful message should display")]
        public void ThenSuccessfulMessageShouldDisplay()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
