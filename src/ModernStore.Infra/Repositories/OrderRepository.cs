using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Infra.Contexts;

namespace ModernStore.Infra.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ModernStoreDataContext _context;

        public OrderRepository(ModernStoreDataContext context)
        {
            _context = context;
        }

        public void Save(Order order)
        {
            _context.Orders.Add(order);
        }
    }
}
