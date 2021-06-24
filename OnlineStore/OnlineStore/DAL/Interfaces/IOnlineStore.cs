using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.DAL.Interfaces
{
    public interface IOnlineStore<T> where T:class
    {
        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null,
    Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,string includeProperties = "");
        T GetById(int id);
        T GetByIdWithOutTracking(int id);
        void Insert(T model);
        void Delete(int id);
        void Update(T model);
    }
}
