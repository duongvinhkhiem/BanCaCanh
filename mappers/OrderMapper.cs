using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BanCaCanh.dto.order;
using BanCaCanh.models;

namespace BanCaCanh.mappers
{
    public static class OrderMapper
    {
        public static OrderDto ToOrderDto(this Order orderModel, AddressDto addressDto)
        {
            return new OrderDto
            {
                Id = orderModel.Id,
                Note = orderModel.Note,
                Status = orderModel.Status,
                CreatedAt = orderModel.CreatedAt,
                Address = addressDto
            };
        }
        public static Order ToCreateOrderDto(this CreateOrderDto dto)
        {
            return new Order
            {
                AddressId = dto.AddressId,
                Note = dto.Note,
                Status = "pending",
            };
        }
        public static OrderDetail ToCreateOrderDetail(this CreateOrderDetailDto dto, int orderId, decimal price)
        {
            return new OrderDetail
            {
                OrderId = orderId,
                Price = price,
                ProductId = dto.ProductId,
                Quantity = dto.Quantity,
            };
        }
    }
}