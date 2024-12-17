using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BanCaCanh.data;
using BanCaCanh.dto.category;
using BanCaCanh.extensions;
using BanCaCanh.Interface;
using BanCaCanh.mappers;
using BanCaCanh.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BanCaCanh.controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly ICategoryRepository _categoryRepo;

        public CategoryController(UserManager<AppUser> userManager, AppDbContext context, ICategoryRepository categoryRepo)
        {
            _userManager = userManager;
            _categoryRepo = categoryRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryRepo.GetAllAsync();
            var categoriesDto = categories.Select(s => s.ToCategoryDto());
            return Ok(categoriesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var category = await _categoryRepo.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category.ToCategoryDto());
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto categoryDto)
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            if (appUser == null)
            {
                return BadRequest(new { message = "Người dùng không tồn tại" });
            }
            var categoryModel = categoryDto.ToCreateCategoryDto();
            await _categoryRepo.CreateAsync(categoryModel);
            return CreatedAtAction(nameof(GetById), new { id = categoryModel.Id }, categoryModel.ToCategoryDto());
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateCategory([FromRoute] int id, [FromBody] CreateCategoryDto categoryDto)
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            if (appUser == null)
            {
                return BadRequest(new { message = "Người dùng không tồn tại" });
            }
            var categoryModel = await _categoryRepo.UpdateAsync(id, categoryDto);
            if (categoryModel == null)
            {
                return NotFound();
            }

            return Ok(categoryModel.ToCategoryDto());
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            if (appUser == null)
            {
                return BadRequest(new { message = "Người dùng không tồn tại" });
            }
            var categoryModel = await _categoryRepo.DeleteAsync(id);
            if (categoryModel == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}