using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BanCaCanh.data;
using BanCaCanh.dto.order;
using BanCaCanh.Interface;
using BanCaCanh.models;
using Microsoft.EntityFrameworkCore;

namespace BanCaCanh.repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;
        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Order> CreateOrder(Order orderModel)
        {
            await _context.Orders.AddAsync(orderModel);
            await _context.SaveChangesAsync();
            return orderModel;
        }

        public async Task<OrderDetail> CreateOrderDetail(OrderDetail orderDetailModel)
        {
            await _context.OrderDetails.AddAsync(orderDetailModel);
            await _context.SaveChangesAsync();
            return orderDetailModel;
        }

        public Task<List<Order>> GetAllOrder()
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetUserOrder(string AppUserId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<OrderDetail>> PayOrder(List<OrderDetail> orderDetailModel)
        {
            foreach (var item in orderDetailModel)
            {
                await _context.OrderDetails.AddAsync(item);
            }
            await _context.SaveChangesAsync();

            return orderDetailModel;
        }
    }
}