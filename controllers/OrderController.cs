using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BanCaCanh.dto.order;
using BanCaCanh.extensions;
using BanCaCanh.helper;
using BanCaCanh.Interface;
using BanCaCanh.mappers;
using BanCaCanh.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BanCaCanh.controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly UserManager<AppUser> _usermanager;
        private readonly IOrderRepository _orderRepo;
        private readonly IProductRepository _productRepo;
        public OrderController(UserManager<AppUser> usermanager, IOrderRepository orderRepo, IProductRepository productRepo)
        {
            _usermanager = usermanager;
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
        [HttpGet("revenue")]
        [Authorize]
        public async Task<IActionResult> GetRenevue()
        {
            var revenue = await _orderRepo.SumOrder();
            var dto = new Money
            {
                Revenue = revenue
            };
            return Ok(dto);
        }
        [HttpGet("user")]
        [Authorize]
        public async Task<IActionResult> GetUserOrder([FromQuery] PaginationObject paginationObject)
        {
            var username = User.GetUsername();
            var appUser = await _usermanager.FindByNameAsync(username);
            if (appUser == null)
            {
                return BadRequest(new { message = "Người dùng không tồn tại" });
            }
            var list = await _orderRepo.GetUserOrder(appUser.Id, paginationObject);
            var orders = list.Select(p => p.ToOrderDto(p.Address.ToAddressDto()));
            return Ok(orders);
        }
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateOrder([FromRoute] int id, [FromBody] GetConfirm get)
        {
            var order = await _orderRepo.Update(id, get.Confirm);
            if (order == null)
            {
                return NotFound();
            }
            var orderDto = order.ToOrderDto(order.Address.ToAddressDto());
            return Ok(orderDto);
        }
    }
}