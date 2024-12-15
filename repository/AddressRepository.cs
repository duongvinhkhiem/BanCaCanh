using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BanCaCanh.data;
using BanCaCanh.Interface;
using BanCaCanh.models;

namespace BanCaCanh.repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AppDbContext _context;
        public AddressRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Address> CreateUserAddress(Address addressModel)
        {
            await _context.AddAsync(addressModel);
            await _context.SaveChangesAsync();
            return addressModel;
        }

        public Task<List<Address>> GetUserAddress(string appUserId)
        {
            throw new NotImplementedException();
        }
    }
}