using System;
using System.Collections.Generic;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Commands.Results;

namespace ModernStore.Domain.Repositories
{
    public interface IProductRepository
    {
        Product Get(Guid id);
        IEnumerable<GetProductListCommandResult> Get();
    }
}
