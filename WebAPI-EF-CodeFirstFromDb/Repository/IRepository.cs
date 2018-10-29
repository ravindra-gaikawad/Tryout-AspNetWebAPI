using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace WebAPI_EF_CodeFirstFromDb.Repository
{
    interface IRepository<T> where T : class
    {
        T Get(int id);
        IQueryable<T> GetAll();
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        void Save();
    }
}