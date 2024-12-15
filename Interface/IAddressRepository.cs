using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BanCaCanh.models;

namespace BanCaCanh.Interface
{
    public interface IAddressRepository
    {
        Task<List<Address>> GetUserAddress(string appUserId);
        Task<Address> CreateUserAddress(Address addressModel);

    }
}