using System.Data.Entity.ModelConfiguration;
using ModernStore.Domain.Entities;

namespace ModernStore.Infra.Mappings
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("User");
            HasKey(x => x.Id);
            Property(x => x.Username).IsRequired().HasMaxLength(20);
            Property(x => x.Password).IsRequired().HasMaxLength(32).IsFixedLength();
            Property(x => x.Active);
        }
    }
}
