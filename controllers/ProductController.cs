using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BanCaCanh.dto.category;
using BanCaCanh.dto.product;
using BanCaCanh.Interface;
using BanCaCanh.mappers;
using BanCaCanh.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BanCaCanh.controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepo;
        private readonly IProductImage _productImageRepo;
        public ProductController(IProductRepository productRepo, IProductImage productImageRepo)
        {
            _productRepo = productRepo;
            _productImageRepo = productImageRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productRepo.GetAllAsync();
            var productDto = new List<ProductDto>();
            foreach (var item in products)
            {
                var images = await _productImageRepo.GetAllAsync(item.Id);
                var product = item.ToProductDto(images);
                product.ProductImages = images;
                productDto.Add(product);
            }
            return Ok(productDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var product = await _productRepo.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound(new { message = "Sản phẩm không tồn tại" });
            }
            var images = await _productImageRepo.GetAllAsync(id);
            return Ok(product.ToProductDto(images));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromForm] CreateProductDto productDto)
        {
            if (productDto.ProductImages == null || productDto.ProductImages.Count == 0 || productDto.ProductImages.Count > 4)
            {
                return BadRequest(new { message = "Phải có ít nhất 1 hình ảnh và không quá 4 hình ảnh." });
            }
            var productModel = productDto.ToCreateProductDto();
            await _productRepo.CreateAsync(productModel);

            for (int i = 0; i < productDto.ProductImages.Count; i++)
            {
                var image = productDto.ProductImages[i];
                var filename = $"{DateTime.Now:yyyyMMddHHmmss}{i}{Path.GetExtension(image.FileName)}";
                var filePath = Path.Combine("uploads", filename);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }
                var productImage = new ProductImage
                {
                    ProductId = productModel.Id,
                    ImageUrl = $"/uploads/{filename}"
                };
                await _productImageRepo.CreateAsync(productImage);
            }

            var images = await _productImageRepo.GetAllAsync(productModel.Id);

            return CreatedAtAction(nameof(GetById), new { id = productModel.Id }, productModel.ToProductDto(images));
        }

        [HttpPost("visible/{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            var productModel = await _productRepo.DeleteAsync(id);
            if (productModel == null)
            {
                return NotFound(new { message = "Sản phẩm không tồn tại" });
            }
            return Ok(new { message = "Xóa thành công" });
        }
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateProduct([FromRoute] int id, UpdateProductDto productDto)
        {
            var productModel = await _productRepo.UpdateAsync(id, productDto);
            if (productModel == null)
            {
                return NotFound(new { message = "Sản phẩm không tồn tại" });
            }
            var images = await _productImageRepo.GetAllAsync(id);
            return Ok(productModel.ToProductDto(images));
        }
    }
}
