using System;
using System.Collections.Generic;

namespace Mc2.CrudTest.Framework
{
    public abstract class AggregateRoot<T>
    {
        protected AggregateRoot(T id)
        {
            Id = id;
            CreateDateTime = DateTime.Now;
        }

        protected AggregateRoot()
        {
        }

        public T Id { get; set; }

        public DateTime CreateDateTime { get; protected set; }

        public DateTime? ModifiedDateTime { get; protected set; }

        public DateTime? DeletedDateTime { get; protected set; }

        public bool IsDeleted { get; protected set; }

        public List<DomainEvent> UncommittedEvents { get; set; }

        protected void MarkAsRemove()
        {
            IsDeleted = true;
            DeletedDateTime = DateTime.Now;
        }

        protected void PublishEvent(DomainEvent @event)
        {
            //UncommittedEvents.Add(@event);
        }
    }
}