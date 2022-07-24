using System;
using System.Linq;
using System.Reflection;
using Mc2.CrudTest.FacadeService.Customers;
using Mc2.CrudTest.Framework;
using Mc2.CrudTest.Persistence.EFCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Mc2.CrudTest.Presentation.Server
{
    public static class CompositionRoot
    {
        public static void RegisterDependencies(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            RegisterDbContexts(services, configuration);

            RegisterDomainServices(services);

            RegisterFacades(services);

            RegisterRepositories(services);
        }

        public static void RegisterDbContexts(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CrudTestDbContext>(builder => { builder.UseSqlServer(configuration.GetConnectionString("DbConnection")); });
        }

        public static void RegisterDomainServices(IServiceCollection services)
        {
            //services.RegisterServices(typeof(DuplicateCustomerDomainService).Assembly, typeof(IDomainService));
        }

        public static void RegisterFacades(IServiceCollection services)
        {
            services.RegisterServices(typeof(CustomerFacadeService).Assembly, typeof(IFacadeService));
        }

        public static void RegisterRepositories(IServiceCollection services)
        {
            //services.RegisterServices(typeof(CustomerRepository).Assembly, typeof(IRepository));
        }

        public static void RegisterServices(this IServiceCollection services, Assembly fromAssembly, Type serviceType)
        {
            var allServices =
                fromAssembly.ExportedTypes
                            .Where(type => !type.IsInterface)
                            .Where(type => serviceType.IsAssignableFrom(type))
                            .ToList();

            foreach (var service in allServices)
            {
                var serviceTypes = service.GetInterfaces()
                                          .Where(itf => serviceType.IsAssignableFrom(itf))
                                          .Where(itf => itf != serviceType)
                                          .ToList();

                foreach (var type in serviceTypes)
                {
                    services.TryAddScoped(type, service);
                }
            }
        }
    }
}