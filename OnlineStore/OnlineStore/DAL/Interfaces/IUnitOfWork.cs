using OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IOnlineStore<Order> OrderRepo { get; }

        IOnlineStore<Product> ProductRepo { get; }

        IOnlineStore<ProductReview> ProductReviewRepo { get; }

        IOnlineStore<User> UserRepo { get; }


        void Save();
    }
}
