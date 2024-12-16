using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BanCaCanh.data;
using BanCaCanh.Interface;
using BanCaCanh.models;
using Microsoft.EntityFrameworkCore;

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


        public async Task<List<Address>> GetUserAddress(string appUserId)
        {
            return await _context.Addresses.Where(p => p.AppUserId == appUserId && p.IsVisible != false).ToListAsync();
        }

        public async Task<Address?> VisibleAddress(int id)
        {
            var addressModel = await _context.Addresses.FirstOrDefaultAsync(s => s.Id == id);
            if (addressModel == null)
            {
                return null;
            }
            addressModel.IsVisible = false;
            await _context.SaveChangesAsync();
            return addressModel;
        }
    }
}