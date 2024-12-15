using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BanCaCanh.data;
using BanCaCanh.dto.order;
using BanCaCanh.Interface;
using BanCaCanh.models;

namespace BanCaCanh.repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;
        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<Order> CreateOrder(int AddressId)
        {
            throw new NotImplementedException();
        }

        public Task<Order> CreateOrderDetail(int OrderId, int ProductId)
        {
            throw new NotImplementedException();
        }

        public async Task<Address> CreateUserAddress(Address addressModel)
        {
            await _context.AddAsync(addressModel);
            await _context.SaveChangesAsync();
            return addressModel;
        }

        public Task<List<Order>> GetAllOrder()
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetUserOrder(string AppUserId)
        {
            throw new NotImplementedException();
        }

        public Task<Order> PayOrder(int OrderId, List<int> ProductId)
        {
            throw new NotImplementedException();
        }
    }
}