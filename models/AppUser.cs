using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BanCaCanh.models
{
    public class AppUser : IdentityUser
    {
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public List<Address> Addresses { get; set; } = new List<Address>();
    }
}