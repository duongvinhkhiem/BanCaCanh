using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BanCaCanh.models
{
    [Table("Orders")]
    public class Order
    {
        public int Id { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}