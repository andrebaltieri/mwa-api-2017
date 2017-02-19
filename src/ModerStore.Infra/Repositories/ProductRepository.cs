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
    public class ProductRepository : IProductRepository
    {
        public readonly ModernStoreDataContext _context;

        public ProductRepository(ModernStoreDataContext context)
        {
            _context = context;
        }
        public Product Get(Guid id)
        {
            return _context.Products.AsNoTracking()
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
