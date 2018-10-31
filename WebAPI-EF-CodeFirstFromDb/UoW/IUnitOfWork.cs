namespace WebAPI_EF_CodeFirstFromDb.UoW
{
    public interface IUnitOfWork
    {
        void BeginTransaction();

        void CommitTransaction();

        void RollbackTransaction();
    }
}
