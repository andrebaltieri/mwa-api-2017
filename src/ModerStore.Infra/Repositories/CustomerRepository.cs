using ModernStore.Domain.Repositories;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModernStore.Domain.Entities;
using ModerStore.Infra.Contexts;

namespace ModerStore.Infra.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public readonly ModernStoreDataContext _context;

        public CustomerRepository(ModernStoreDataContext context)
        {
            _context = context;
        }

        public bool DocumentExists(string document)
        {
            return _context.Customer.Any(x => x.Document.Number == document);
        }

        public Customer Get(Guid id)
        {
            return _context.Customer
                .Include(x => x.User)
                .FirstOrDefault(x => x.Id == id);
        }

        public void Save(Customer customer)
        {
            _context.Customer.Add(customer);
        }

        public void Update(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
        }
    }
}
