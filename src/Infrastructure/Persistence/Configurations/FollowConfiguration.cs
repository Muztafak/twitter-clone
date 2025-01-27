using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TwitterClone.Infrastructure.Persistence.Configurations
{
    public class FollowConfiguration : IEntityTypeConfiguration<Follow>
    {
        public void Configure(EntityTypeBuilder<Follow> builder)
        {
            builder.HasKey(f => new { f.FollowerId, f.FollowedId});
            builder.HasOne(f => f.Followed).WithMany(u => u.Followers);
            builder.HasOne(f => f.Follower).WithMany(u => u.Followeds);
            builder.Ignore(f => f.DomainEvents);
        }
    }
}