using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YGN.StoreApp.Entities.Models;
using YGN.StoreApp.Repositories.Contracts;

namespace YGN.StoreApp.Repositories.Concrete
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(RepositoryContext context) : base(context)
        {
        }

        public IQueryable<Order> Orders => _context.Orders
            .Include(x => x.Lines)
            .ThenInclude(x => x.Product)                    //Eager Loading
            .OrderBy(x => x.Shipped)
            .ThenByDescending(x => x.OrderId);

        public int NumberOfInProcess => _context.Orders.Count(x => x.Shipped.Equals(false));

        public void Complete(int id)
        {
            var order = FindByCondition(x => x.OrderId.Equals(id), true);
            if (order is null)
                throw new Exception("Order could not found!");
            order.Shipped = true;
        }

        public Order? GetOneOrder(int id)
        {
            return FindByCondition(x => x.OrderId.Equals(id), false);
        }

        public void SaveOrder(Order order)
        {
            _context.AttachRange(order.Lines.Select(x => x.Product));
            if (order.OrderId == 0)
                _context.Orders.Add(order);
            _context.SaveChanges();
        }
    }
}
