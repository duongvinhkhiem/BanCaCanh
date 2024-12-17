using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanCaCanh.dto.order
{
    public class CreateOrderDetailDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}