using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Mc2.CrudTest.Presentation.Server;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SpecFlow.Autofac;
using TechTalk.SpecFlow;

namespace Mc2.CrudTest.AcceptanceTests
{
    public static class TestDependencies
    {
        [ScenarioDependencies]
        public static ContainerBuilder CreateContainerBuilder()
        {
            var services = new ServiceCollection();
            var configuration = new ConfigurationRoot(new List<IConfigurationProvider>());
            CompositionRoot.RegisterDependencies(services, configuration);

            var builder = new ContainerBuilder();
            builder.RegisterTypes(typeof(TestDependencies).Assembly.GetTypes().Where(t => Attribute.IsDefined(t, typeof(BindingAttribute))).ToArray()).SingleInstance();
            
            return builder;
        }
    }
}