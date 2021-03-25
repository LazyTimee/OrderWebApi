using OrderWebApi.Etities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace OrderWebApi.Services
{
    public class Talabat : iServiceProc
    {
        public void Process(string orderDetail, AppContext context)
        {
            if (!string.IsNullOrEmpty(orderDetail) && context != null)
            {
                OrderDetail orderDet = JsonSerializer.Deserialize<OrderDetail>(orderDetail);
                var count = orderDet.Products.Count;
                foreach (var prod in orderDet.Products)
                {
                    prod.PaidPrice = -prod.PaidPrice;
                }
                var order = context.Orders.FirstOrDefault(x => x.OrderNum == orderDet.OrdeNumber);
                if (order != null)
                {
                    order.CovertedOrder = JsonSerializer.Serialize(orderDet);
                    context.SaveChanges();
                }
            }
        }
    }
}
