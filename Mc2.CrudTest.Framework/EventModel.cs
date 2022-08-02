using System;

namespace Mc2.CrudTest.Framework
{
    public class EventModel
    {
        public EventModel()
        {
            Id = Guid.NewGuid();
            CreateDateTime = DateTime.Now;
            IsPublished = false;
        }

        public Guid Id { get; set; }

        public int AggregateId { get; set; }

        public string AggregateName { get; set; }

        public string EventName { get; set; }

        public string Content { get; set; }

        public DateTime CreateDateTime { get; set; }

        public string Version { get; set; }

        public bool IsPublished { get; set; }
    }
}