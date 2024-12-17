using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanCaCanh.dto.order
{
    public class CreateOrderDto
    {
        public int AddressId { get; set; }
        public string Note { get; set; } = string.Empty;
        public List<CreateOrderDetailDto> OrderDetails { get; set; }
    }
}