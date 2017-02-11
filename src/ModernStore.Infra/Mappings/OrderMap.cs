using System.Data.Entity.ModelConfiguration;
using ModernStore.Domain.Entities;

namespace ModernStore.Infra.Mappings
{
    public class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            ToTable("Order");
            HasKey(x => x.Id);
            Property(x => x.CreateDate);
            Property(x => x.DeliveryFee).HasColumnType("money");
            Property(x => x.Discount).HasColumnType("money");
            Property(x => x.Number).IsRequired().HasMaxLength(8).IsFixedLength();
            Property(x => x.Status);

            HasMany(x => x.Items);
            HasRequired(x => x.Customer);
        }
    }
}
