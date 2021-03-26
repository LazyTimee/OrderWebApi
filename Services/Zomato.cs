using OrderWebApi.Etities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace OrderWebApi.Services
{
    public class Zomato : iServiceProc
    {
        private readonly AppContext _context;

        public Zomato(AppContext context)
        {
            _context = context;
        }

        public void Process(string orderDetail)
        {
            if (!string.IsNullOrEmpty(orderDetail))
            {
                OrderDetail orderDet = JsonSerializer.Deserialize<OrderDetail>(orderDetail);
                var count = orderDet.Products.Count;
                foreach (var prod in orderDet.Products)
                {
                    prod.PaidPrice = prod.PaidPrice / count;
                }
                var order = _context.Orders.FirstOrDefault(x => x.OrderNum == orderDet.OrderNumber && !string.IsNullOrEmpty(orderDet.OrderNumber));
                if (order != null)
                {
                    order.CovertedOrder = JsonSerializer.Serialize(orderDet);
                    _context.SaveChanges();
                }
            }
        }
    }
}
