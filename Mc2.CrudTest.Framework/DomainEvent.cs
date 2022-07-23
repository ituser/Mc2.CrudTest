using System;

namespace Mc2.CrudTest.Framework
{
    public abstract record DomainEvent
    {
        protected DomainEvent()
        {
            EventId = Guid.NewGuid();
            PublishDateTime = DateTime.Now;
        }

        public Guid EventId { get; private set; }

        public DateTime PublishDateTime { get; private set; }
    }
}