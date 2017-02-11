using System;
using System.Collections.Generic;
using ModernStore.Domain.Commands.Results;
using ModernStore.Domain.Entities;

namespace ModernStore.Domain.Repositories
{
    public interface IProductRepository
    {
        Product Get(Guid id);
        IEnumerable<GetProductListCommandResult> Get();
    }
}
