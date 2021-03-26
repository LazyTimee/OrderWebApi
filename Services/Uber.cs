using OrderWebApi.Etities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace OrderWebApi.Services
{
    public class Uber : iServiceProc
    {
        private readonly AppContext _context;

        public Uber(AppContext context)
        {
            _context = context;
        }
        public void Process(string orderDetail)
        {
            if (!string.IsNullOrEmpty(orderDetail))
            {
                OrderDetail orderDet = JsonSerializer.Deserialize<OrderDetail>(orderDetail);
                var order = _context.Orders.FirstOrDefault(x => x.OrderNum == orderDet.OrderNumber && !string.IsNullOrEmpty(orderDet.OrderNumber));
                if (order != null)
                {
                    order.CovertedOrder = "Error";
                    _context.SaveChanges();
                    throw new Exception("Uber failed!");
                }
            }
        }
    }
}
