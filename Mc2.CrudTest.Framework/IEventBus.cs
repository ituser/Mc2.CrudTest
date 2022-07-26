namespace Mc2.CrudTest.Framework
{
    public interface IEventBus
    {
        void Publish<TEvent>(TEvent @event);
    }
}