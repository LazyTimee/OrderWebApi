using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderWebApi.Etities
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Coment { get; set; }
        public string Quantity { get; set; }
        public float PaidPrice { get; set; }
        public string UnitPrice { get; set; }
        public string Decription { get; set; }
        public string RemoteCode { get; set; }
        public string VatPercentage { get; set; }
        public string DiscountAmount { get; set; }
    }
}
