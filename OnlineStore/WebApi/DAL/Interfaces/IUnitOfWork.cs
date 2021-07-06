using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Cart> CartRepo { get; }
        void Save();
    }
}
