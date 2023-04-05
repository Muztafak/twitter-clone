
namespace TwitterClone.Domain.Events
{
    public class PostCreatedEvent : DomainEvent
    {
        public Post Item { get; private set; }
        
        public PostCreatedEvent(Post item)
        {
            Item = item;
        }
    }
}