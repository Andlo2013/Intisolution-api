using IntiSolutionApi.Entities;
using IntiSolutionApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IntiSolutionApi.Models
{
    
    public class OrderModel:IOrderModel
    {
        private _DbContext context;

        public OrderModel(_DbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Order>> Get()
        {
            var result = await context.Orders.ToListAsync();
            return result;
        }

        public async Task<Order> GetByID(int orderId)
        {
            var result = await context.Orders
                            .Include(o=>o.Detail)
                  .FirstOrDefaultAsync(c => c.Id == orderId);
            return result;
        }

        public async Task<bool> Save(Order order)
        {
            var rowDB = await GetByID(order.Id);
            if (rowDB == null)
                context.Orders.Add(order);
            else
            {
                rowDB.OrderDate = order.OrderDate;
                rowDB.Detail.RemoveAll(od=>od.OrderId==rowDB.Id);
                foreach(var item in order.Detail)
                {
                    item.OrderId = rowDB.Id;
                    item.TotalPrice = item.Quantity * item.UnitPrice;
                    rowDB.Detail.Add(item);
                }
                context.Entry(rowDB).State = EntityState.Modified;
            }
            await context.SaveChangesAsync();
            return true;
        }
    }
}
