using ModernStore.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModernStore.Domain.Entities;
using ModerStore.Infra.Contexts;
using ModernStore.Domain.Commands.Results;
using System.Data.SqlClient;
using Dapper;
using ModernStore.Shared;

namespace ModerStore.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public readonly ModernStoreDataContext _context;

        public ProductRepository(ModernStoreDataContext context)
        {
            _context = context;
        }

        public IEnumerable<GetProductListCommandResult> Get()
        {
            var query = "SELECT [Id], [Title], [Price], [Image] FROM [Product]";

            using (SqlConnection conn = new SqlConnection(Runtime.ConnectionString))
            {
                conn.Open();
                return conn.Query<GetProductListCommandResult>(query);
            }
        }

        public Product Get(Guid id)
        {
            return _context.Products.AsNoTracking()
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
