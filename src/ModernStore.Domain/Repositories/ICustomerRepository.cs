using System;
using ModernStore.Domain.Entities;

namespace ModernStore.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Customer Get(Guid id);
        Customer GetByUserId(Guid id);
        void Update(Customer customer);
        bool DocumentExists(string document);
        void Save(Customer customer);
    }
}
