using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YGN.StoreApp.Entities.Models;

namespace YGN.StoreApp.Repositories.Contracts
{
    public interface IOrderRepository
    {
        IQueryable<Order> Orders { get; }
        Order? GetOneOrder(int id);
        void Complete(int id);
        void SaveOrder(Order order);
        int NumberOfInProcess { get; }
    }
}
