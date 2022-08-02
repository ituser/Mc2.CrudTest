using System;
using Mc2.CrudTest.AcceptanceTests.Customers;
using TechTalk.SpecFlow;

namespace Mc2.CrudTest.AcceptanceTests
{
    public class CustomerHelpers
    {
        public static SpecCustomer CurrentCustomer
        {
            get => ScenarioContext.Current.Get<SpecCustomer>("SpecCustomer");

            set
            {
                if (!ScenarioContext.Current.ContainsKey("SpecCustomer"))
                {
                    ScenarioContext.Current.Add("SpecCustomer", value);
                }
                else
                {
                    ScenarioContext.Current["SpecCustomer"] = value;
                }
            }
        }
    }

    public class TestContext
    {
        private readonly ScenarioContext context;

        public TestContext(ScenarioContext context)
        {
            this.context = context;
        }

        public Guid CustomerId
        {
            get => GetValue<Guid>("CustomerId");

            set => SetValue(value, "CustomerId");
        }

        public Exception CurrentException
        {
            get => GetValue<Exception>("Exception");

            set => SetValue(value, "Exception");
        }

        private void SetValue<T>(T value, string key)
        {
            if (context.ContainsKey(key))
            {
                context.Remove(key);
            }

            context.Add(key, value);
        }

        private T GetValue<T>(string key)
        {
            context.TryGetValue(key, out T val);

            return val;
        }
    }
}