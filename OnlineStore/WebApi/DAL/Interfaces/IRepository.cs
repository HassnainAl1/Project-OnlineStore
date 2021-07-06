using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.DAL.Interfaces
{
    public interface IRepository<T> where T:class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Insert(T entity);
        void Delete(int id);
        void Update(T entity);
    }
}