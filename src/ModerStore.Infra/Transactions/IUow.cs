using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModerStore.Infra.Transactions
{
    public interface IUow
    {
        void Commit();
        void Rollback();
    }
}
