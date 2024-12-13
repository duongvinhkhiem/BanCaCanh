using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BanCaCanh.models
{
    [Table("Addresses")]
    public class Address
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public string PhoneNumber { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}