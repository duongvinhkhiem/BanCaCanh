using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanCaCanh.dto.order
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public AddressDto Address { get; set; }
    }
}