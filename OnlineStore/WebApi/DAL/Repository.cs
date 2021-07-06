using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApi.DAL.Interfaces;
using WebApi.Models;

namespace WebApi.DAL
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly OnlineStoreDBEntities _context;
        private readonly DbSet<T> dbEntity;

        public Repository(OnlineStoreDBEntities context)
        {
            _context = context;
            dbEntity = _context.Set<T>();

        }


        public IEnumerable<T> GetAll()
        {
            return dbEntity.ToList();
        }

        public T GetById(int id)
        {
            return dbEntity.Find(id);
            
        }

        public void Insert(T entity)
        {
            dbEntity.Add(entity);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            T data = dbEntity.Find(id);
            dbEntity.Remove(data);
        }
    }
}