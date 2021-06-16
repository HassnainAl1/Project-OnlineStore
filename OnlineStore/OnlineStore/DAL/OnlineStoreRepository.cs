using OnlineStore.DAL.Interfaces;
using OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace OnlineStore.DAL
{
    public class OnlineStoreRepository<T> : IOnlineStore<T> where T : class
    {
        private readonly OnlineStoreDBEntities _context;
        private readonly DbSet<T> dbEntity;

        public OnlineStoreRepository(OnlineStoreDBEntities context)
        {
            _context = context;
            dbEntity = _context.Set<T>();
        }

        public void Delete(int id)
        {
            T data=dbEntity.Find(id);
            dbEntity.Remove(data);

        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = dbEntity;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public T GetById(int id)
        {
            return dbEntity.Find(id);
        }

        public void Insert(T model)
        {
             dbEntity.Add(model) ;
        }

        public void Update(T model)
        {
            _context.Entry(model).State = EntityState.Modified;
        }
    }
}