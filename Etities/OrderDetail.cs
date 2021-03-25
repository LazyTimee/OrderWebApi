using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderWebApi.Etities
{
    public class OrderDetail
    {
        public string OrdeNumber { get; set; }
        public List<Product> Products { get; set; }
    }
}
