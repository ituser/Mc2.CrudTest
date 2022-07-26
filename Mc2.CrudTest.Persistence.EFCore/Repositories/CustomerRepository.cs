using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mc2.CrudTest.Domain.Models.Customers;
using Mc2.CrudTest.Framework;
using Newtonsoft.Json;

namespace Mc2.CrudTest.Persistence.EFCore.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CrudTestDbContext dbContext;

        public CustomerRepository(CrudTestDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<Customer> Get(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public async Task Create(Customer customer)
        {
            dbContext.Add(customer);

            PersistEvents(customer);

            await dbContext.SaveChangesAsync();
        }

        public Task Update(Customer existingCustomer)
        {
            throw new NotImplementedException();
        }

        public Task Remove(Customer existingCustomer)
        {
            throw new NotImplementedException();
        }

        private void PersistEvents(Customer customer)
        {
            var events = customer.UncommittedEvents.Select(x => new EventModel
                                                                {
                                                                    AggregateId = customer.Id,
                                                                    AggregateName = customer.GetType().Name,
                                                                    EventName = x.GetType().Name,
                                                                    Version = "v1",
                                                                    Content = JsonConvert.SerializeObject(customer,
                                                                                                          Formatting.Indented,
                                                                                                          new JsonSerializerSettings
                                                                                                          {
                                                                                                              TypeNameHandling = TypeNameHandling.All,
                                                                                                              NullValueHandling = NullValueHandling.Ignore
                                                                                                          }),
                                                                }).ToList();
            dbContext.EventModels.AddRange(events);

            PublishPersistEvents(events);
        }

        private void PublishPersistEvents(List<EventModel> eventModels)
        {
            foreach (var eventModel in eventModels)
            {
                //Publish(eventModel);
            }
        }
    }
}