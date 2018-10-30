using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI_EF_CodeFirstFromDb.UoW
{
    public interface IUnitOfWork
    {
        Repository.Repository Repository { get; }

        void BeginTransaction();

        void CommitTransaction();

        void RollbackTransaction();

        void Complete();
    }
}
