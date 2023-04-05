
namespace TwitterClone.Domain.Events
{
    public class LikeCreatedEvent : DomainEvent
    {
        public Like Item { get; private set; }
        
        public LikeCreatedEvent(Like item)
        {
            Item = item;
        }
    }
}