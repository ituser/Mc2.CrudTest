﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Mc2.CrudTest.AcceptanceTests.Customers
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class CustomerCreateReadEditDeleteProductScopeFeature : object, Xunit.IClassFixture<CustomerCreateReadEditDeleteProductScopeFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "CustomerCrudProductScope.feature"
#line hidden
        
        public CustomerCreateReadEditDeleteProductScopeFeature(CustomerCreateReadEditDeleteProductScopeFeature.FixtureData fixtureData, Mc2_CrudTest_AcceptanceTests_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Customers", "Customer Create Read Edit Delete Product Scope", @"    Background
        Given system error codes are following
          | Code | Description                                                |
          | 101  | Invalid Mobile Number                                      |
          | 102  | Invalid Email address                                      |
          | 103  | Invalid Bank Account Number                                |
          | 201  | Duplicate customer by First-name, Last-name, Date-of-Birth |
          | 202  | Duplicate customer by Email address                        |", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Create Read Edit Delete Customer")]
        [Xunit.TraitAttribute("FeatureTitle", "Customer Create Read Edit Delete Product Scope")]
        [Xunit.TraitAttribute("Description", "Create Read Edit Delete Customer")]
        [Xunit.InlineDataAttribute("1", "John", "Doe", "john@doe.com", "+989121234567", "01-JAN-2000", "IR000000000000001", new string[0])]
        public virtual void CreateReadEditDeleteCustomer(string iD, string firstName, string lastName, string email, string phoneNumber, string dateOfBirth, string bankAccountNumber, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("ID", iD);
            argumentsOfScenario.Add("FirstName", firstName);
            argumentsOfScenario.Add("LastName", lastName);
            argumentsOfScenario.Add("Email", email);
            argumentsOfScenario.Add("PhoneNumber", phoneNumber);
            argumentsOfScenario.Add("DateOfBirth", dateOfBirth);
            argumentsOfScenario.Add("BankAccountNumber", bankAccountNumber);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create Read Edit Delete Customer", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 12
    this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 13
        testRunner.When(string.Format("user creates customer with {0}", firstName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 14
        testRunner.And(string.Format("lastname of {0}", lastName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 15
        testRunner.And(string.Format("date of birth of {0}", dateOfBirth), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 16
        testRunner.And(string.Format("email of {0}", email), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 17
        testRunner.And(string.Format("Phone number of {0}", phoneNumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 18
        testRunner.Then(string.Format("user can lookup customer by ID of {0} and get \"1\" records", iD), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 19
        testRunner.When(string.Format("user edit customer by ID of {0} with new email of \"new@email.com\"", iD), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 20
        testRunner.Then(string.Format("user can lookup customer by ID of {0} and get \"1\" records", iD), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 21
        testRunner.And("return record email is \"new@email.com\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 22
        testRunner.When(string.Format("user delete customer by ID of {0}", iD), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 23
        testRunner.Then(string.Format("user can lookup customer by ID of {0} and get \"0\" records", iD), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Create a duplicate customer by firstname, lastname and date of birth")]
        [Xunit.TraitAttribute("FeatureTitle", "Customer Create Read Edit Delete Product Scope")]
        [Xunit.TraitAttribute("Description", "Create a duplicate customer by firstname, lastname and date of birth")]
        [Xunit.InlineDataAttribute("1", "John", "Doe", "john@doe.com", "01-JAN-2000", "IR000000000000001", "+989123491682", new string[0])]
        public virtual void CreateADuplicateCustomerByFirstnameLastnameAndDateOfBirth(string iD, string firstName, string lastName, string email, string dateOfBirth, string bankAccountNumber, string phoneNumber, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("ID", iD);
            argumentsOfScenario.Add("FirstName", firstName);
            argumentsOfScenario.Add("LastName", lastName);
            argumentsOfScenario.Add("Email", email);
            argumentsOfScenario.Add("DateOfBirth", dateOfBirth);
            argumentsOfScenario.Add("BankAccountNumber", bankAccountNumber);
            argumentsOfScenario.Add("PhoneNumber", phoneNumber);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create a duplicate customer by firstname, lastname and date of birth", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 29
    this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                            "ID",
                            "FirstName",
                            "LastName",
                            "Email",
                            "DateOfBirth",
                            "BankAccountNumber",
                            "PhoneNumber"});
                table1.AddRow(new string[] {
                            "1",
                            "JOHN",
                            "DOE",
                            "john@doe.com",
                            "01-JAN-2000",
                            "IR000000000000001",
                            "+989123491682"});
#line 30
        testRunner.Given("system has existing customer", ((string)(null)), table1, "Given ");
#line hidden
#line 33
        testRunner.When(string.Format("user creates customer with {0}", firstName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 34
        testRunner.And(string.Format("lastname of {0}", lastName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 35
        testRunner.And(string.Format("date of birth of {0}", dateOfBirth), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 36
        testRunner.And(string.Format("email of {0}", email), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 37
        testRunner.Then("system responds with \"201\"  error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                CustomerCreateReadEditDeleteProductScopeFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                CustomerCreateReadEditDeleteProductScopeFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion