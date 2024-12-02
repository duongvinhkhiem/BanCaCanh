using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BanCaCanh.models;

namespace BanCaCanh.Interface
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}