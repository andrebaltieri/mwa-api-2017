using ModernStore.Domain.Entities;

namespace ModernStore.Domain.Repositories
{
    public interface IOrderRepository
    {
        void Save(Order order);
    }
}
