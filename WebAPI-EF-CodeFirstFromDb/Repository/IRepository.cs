namespace WebAPI_EF_CodeFirstFromDb.Repository
{
    using System.Linq;
    using WebAPI_EF_CodeFirstFromDb.Models;

    public interface IRepository
    {
        T Get<T>(int id)
            where T : BaseEntity;

        IQueryable<T> GetAll<T>()
            where T : BaseEntity;

        void Add<T>(T entity)
            where T : BaseEntity;

        void Delete<T>(T entity)
            where T : BaseEntity;

        void Edit<T>(T entity)
            where T : BaseEntity;
    }
}