using ModerStore.Infra.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModerStore.Infra.Transactions
{
    public class Uow : IUow
    {
        private readonly ModernStoreDataContext _context;

        public Uow(ModernStoreDataContext context)
        {
            _context = context;
        }
        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
            // Do nothing :)
        }
    }
}
