using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TwitterClone.Infrastructure.Persistence.Configurations
{
    public class LikeConfigurations : IEntityTypeConfiguration<Like>
    {
        public void Configure(EntityTypeBuilder<Like> builder)
        {
            builder.HasKey(l => new { l.CreatedById, l.PostId });
            builder.Ignore(l => l.DomainEvents);    
        }
    }
}