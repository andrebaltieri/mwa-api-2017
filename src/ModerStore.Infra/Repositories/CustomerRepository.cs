using ModernStore.Domain.Repositories;
using System;
using System.Data.Entity;
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
    public class CustomerRepository : ICustomerRepository
    {
        public readonly ModernStoreDataContext _context;

        public CustomerRepository(ModernStoreDataContext context)
        {
            _context = context;
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public bool DocumentExists(string document)
        {
            return _context.Customers.Any(x => x.Document.Number == document);
        }

        public GetCustomerCommandResult Get(string username)
        {
            //return _context.Customer.AsNoTracking()
            //    .Include(x => x.User)
            //    .Select(x => new GetCustomerCommandResult()
            //    {
            //        Name = x.Name.ToString(),
            //        Document = x.Document.Number,
            //        Active = x.User.Active,
            //        Email = x.Email.Address,
            //        Password = x.User.Password,
            //        Username = x.User.Password

            //    })
            //    .FirstOrDefault(x => x.Username == username);

            var query = "SELECT * FROM [GetCustomerInfoView] WHERE [Active]=1 AND [Username]=@username";

            using (SqlConnection conn = new SqlConnection(Runtime.ConnectionString))
            {
                conn.Open();
                return conn.Query<GetCustomerCommandResult>
                    (query, new { username = username })
                    .FirstOrDefault();
            }

        }

        public Customer Get(Guid id)
        {
            return _context.Customers
                .Include(x => x.User)
                .FirstOrDefault(x => x.Id == id);
        }

        public Customer GetByUsername(string username)
        {
            return _context.Customers
                .Include(x => x.User)
                .AsNoTracking()
                .FirstOrDefault(x => x.User.Username == username);
        }

        public void Save(Customer customer)
        {
            _context.Customers.Add(customer);
        }

        public void Update(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
        }
    }
}
