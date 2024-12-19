using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BanCaCanh.dto.order;
using BanCaCanh.helper;
using BanCaCanh.models;

namespace BanCaCanh.Interface
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllOrder(PaginationObject paginationObject);
        Task<List<Order>> GetOrderDetail(int orderId);
        Task<List<Order>> GetUserOrder(string AppUserId);
        Task<Order> CreateOrder(Order orderModel);
        Task<OrderDetail> CreateOrderDetail(OrderDetail orderDetailModel);
        Task<Order> PayOrder(Order orderModel, List<CreateOrderDetailDto> orderDetailModel);
    }
}