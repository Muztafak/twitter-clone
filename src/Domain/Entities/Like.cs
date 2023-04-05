using System.Collections.Generic;

namespace TwitterClone.Domain.Entities
{
    public class Like : AuthorAuditableEntity, IHasDomainEvent
    {
        public Post Post { get; set; }
        public int PostId { get; set; }
        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}