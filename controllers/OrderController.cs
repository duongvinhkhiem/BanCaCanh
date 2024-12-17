using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BanCaCanh.dto.order;
using BanCaCanh.Interface;
using BanCaCanh.mappers;
using BanCaCanh.models;
using Microsoft.AspNetCore.Mvc;

namespace BanCaCanh.controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IProductRepository _productRepo;
        public OrderController(IOrderRepository orderRepo, IProductRepository productRepo)
        {
            _orderRepo = orderRepo;
            _productRepo = productRepo;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderDto([FromBody] CreateOrderDto createOrderDto)
        {
            var orderModel = createOrderDto.ToCreateOrderDto();
            var order = await _orderRepo.CreateOrder(orderModel);
            foreach (var item in createOrderDto.OrderDetails)
            {
                var product = await _productRepo.GetByIdAsync(item.ProductId);
                var orderDetail = item.ToCreateOrderDetail(order.Id, product.Price);
                await _orderRepo.CreateOrderDetail(orderDetail);
            }
            return Ok();
        }

    }
}