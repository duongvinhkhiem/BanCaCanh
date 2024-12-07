using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BanCaCanh.dto.product_controller;
using BanCaCanh.Interface;
using BanCaCanh.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BanCaCanh.controllers
{
    [Route("api/product_category")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategory _productCategory;
        private readonly IProductRepository _productRepo;
        private readonly ICategoryRepository _categoryRepo;

        public ProductCategoryController(IProductCategory productCategory, IProductRepository productRepo, ICategoryRepository categoryRepo)
        {
            _productCategory = productCategory;
            _productRepo = productRepo;
            _categoryRepo = categoryRepo;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] ProductCategoryDto productCategoryDto)
        {
            var product = await _productRepo.GetByIdAsync(productCategoryDto.ProductId);
            var category = await _categoryRepo.GetByIdAsync(productCategoryDto.CategoryId);

            if (product == null) return NotFound("Sản phẩm không tồn tại");
            if (category == null) return NotFound("Loại hàng không tồn tại");

            var exist = await _productCategory.ProductCategoryExists(productCategoryDto);
            if (exist)
            {
                return BadRequest(new { message = "Cặp danh mục sản phẩm đã tồn tại" });
            }

            var model = new ProductCategory
            {
                ProductId = product.Id,
                CategoryId = category.Id
            };
            await _productCategory.CreateAsync(model);

            if (model == null)
            {
                return StatusCode(500, "Không thể gán sản phẩm");
            }
            return Ok(productCategoryDto);
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> Delete([FromBody] ProductCategoryDto productCategoryDto)
        {
            var product = await _productRepo.GetByIdAsync(productCategoryDto.ProductId);
            var category = await _categoryRepo.GetByIdAsync(productCategoryDto.CategoryId);

            if (product == null) return NotFound("Sản phẩm không tồn tại");
            if (category == null) return NotFound("Loại hàng không tồn tại");

            var exist = await _productCategory.ProductCategoryExists(productCategoryDto);
            if (!exist)
            {
                return BadRequest(new { message = "Sản phẩm không chưa gán vào danh mục" });
            }
            var model = await _productCategory.DeleteAsync(productCategoryDto);
            if (model == null)
            {
                return BadRequest(new { message = "Không thể xóa danh mục - sản phẩm" });
            }
            return NoContent();
        }
    }
}