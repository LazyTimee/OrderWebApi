using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderWebApi.Etities
{
    public class OrderDetail
    {
        public string OrderNumber { get; set; }
        public List<Product> Products { get; set; }
    }
}
