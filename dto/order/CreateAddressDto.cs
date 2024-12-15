using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanCaCanh.dto.order
{
    public class CreateAddressDto
    {
        public string Fullname { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public string PhoneNumber { get; set; }
    }
}