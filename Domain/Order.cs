using OrderWebApi.Etities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderWebApi.Domain
{
    public class Order
    {
        public Order()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string SystemType { get; set; }
        public string OrderNum { get; set; }
        public string SourceOrder { get; set; }
        public string CovertedOrder { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
