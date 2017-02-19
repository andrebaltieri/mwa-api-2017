using ModernStore.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModernStore.Domain.Entities;
using ModerStore.Infra.Contexts;

namespace ModerStore.Infra.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public readonly ModernStoreDataContext _context;

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
