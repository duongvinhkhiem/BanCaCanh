using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BanCaCanh.data;
using BanCaCanh.dto.order;
using BanCaCanh.Interface;
using BanCaCanh.mappers;
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

        public async Task<Order> PayOrder(Order orderModel, List<CreateOrderDetailDto> orderDetailModel)
        {
            var order = await CreateOrder(orderModel);
            foreach (var item in orderDetailModel)
            {
                var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == item.ProductId);
                var detail = item.ToCreateOrderDetail(order.Id, product.Price);
                await CreateOrderDetail(detail);
            }
            await _context.SaveChangesAsync();
            return order;
        }
    }
}