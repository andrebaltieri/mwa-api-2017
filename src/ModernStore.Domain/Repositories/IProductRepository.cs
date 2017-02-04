using System;
using System.Collections.Generic;
using ModernStore.Domain.Entities;

namespace ModernStore.Domain.Repositories
{
    public interface IProductRepository
    {
        Product Get(Guid id);
    }
}
