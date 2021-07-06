using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.DAL.Interfaces;
using WebApi.Models;

namespace WebApi.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OnlineStoreDBEntities _context;

        public UnitOfWork()
        {
            _context = new OnlineStoreDBEntities();
        }

        public IRepository<Cart> CartRepo 
        {
            get 
            {
                return new Repository<Cart>(_context);
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}