using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BanCaCanh.dto.category;
using BanCaCanh.dto.product;
using BanCaCanh.Interface;
using BanCaCanh.mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BanCaCanh.controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepo;
        private readonly ICategoryRepository _categoryRepo;
        public ProductController(IProductRepository productRepo, ICategoryRepository categoryRepo)
        {
            _productRepo = productRepo;
            _categoryRepo = categoryRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productRepo.GetAllAsync();
            var productsDto = products.Select(s => s.ToProductDto());
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var product = await _productRepo.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound(new { message = "Sản phẩm không tồn tại" });
            }
            return Ok(product.ToProductDto());
        }

        [HttpPost("{categoryId}")]
        [Authorize]
        public async Task<IActionResult> Create([FromRoute] int categoryId, CreateProductDto productDto)
        {
            if (!await _categoryRepo.CategoryExists(categoryId))
            {
                return NotFound(new { message = "Loại hàng này không tồn tại" });
            }
            var productModel = productDto.ToCreateProductDto(categoryId);
            await _productRepo.CreateAsync(productModel);
            return CreatedAtAction(nameof(GetById), new { id = productModel.Id }, productModel.ToProductDto());
        }
    }
}