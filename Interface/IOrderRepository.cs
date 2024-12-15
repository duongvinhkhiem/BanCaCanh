using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BanCaCanh.dto.order;
using BanCaCanh.models;

namespace BanCaCanh.Interface
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllOrder();
        Task<List<Order>> GetUserOrder(string AppUserId);
        Task<Order> CreateOrder(int AddressId);
        Task<Order> CreateOrderDetail(int OrderId, int ProductId);
        Task<Order> PayOrder(int OrderId, List<int> ProductId);
    }
}