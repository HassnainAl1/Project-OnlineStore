using OnlineStore.DAL.Interfaces;
using OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OnlineStoreDBEntities _context;

        public UnitOfWork()
        {
            _context = new OnlineStoreDBEntities();
        }

        public IOnlineStore<Order> OrderRepo
        {
            get
            {
                return new OnlineStoreRepository<Order>(_context);
            }
        }

        public IOnlineStore<Product> ProductRepo
        {
            get
            {
                return new OnlineStoreRepository<Product>(_context);
            }
        }

        public IOnlineStore<ProductReview> ProductReviewRepo
        {
            get
            {
                return new OnlineStoreRepository<ProductReview>(_context);
            }
        }

        public IOnlineStore<User> UserRepo
        {
            get
            {
                return new OnlineStoreRepository<User>(_context);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}