using System;

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

        public T Id { get; protected set; }

        public bool IsDeleted { get; protected set; }

        public DateTime CreateDateTime { get; protected set; }

        public DateTime ModifiedDateTime { get; protected set; }

        public DateTime DeletedDateTime { get; protected set; }

        protected void MarkAsRemove()
        {
            IsDeleted = true;
            DeletedDateTime = DateTime.Now;
        }

        protected void PublishEvent(DomainEvent @event)
        {
        }
    }
}