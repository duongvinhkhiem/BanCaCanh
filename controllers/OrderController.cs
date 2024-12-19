using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BanCaCanh.dto.order;
using BanCaCanh.helper;
using BanCaCanh.Interface;
using BanCaCanh.mappers;
using BanCaCanh.models;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public async Task<IActionResult> CreateOrderDto([FromBody] CreateOrderDto createOrderDto)
        {
            var orderModel = createOrderDto.ToCreateOrderDto();
            foreach (var item in createOrderDto.OrderDetails)
            {
                var product = await _productRepo.GetByIdAsync(item.ProductId);
                if (product == null)
                {
                    return NotFound(new { message = "Sản phẩm bạn thêm không tồn tại" });
                }

            }
            await _orderRepo.PayOrder(orderModel, createOrderDto.OrderDetails);
            return Ok();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllOrder([FromQuery] PaginationObject paginationObject)
        {
            var list = await _orderRepo.GetAllOrder(paginationObject);
            var orders = list.Select(p => p.ToOrderDto(p.Address.ToAddressDto()));
            return Ok(orders);
        }
    }
}