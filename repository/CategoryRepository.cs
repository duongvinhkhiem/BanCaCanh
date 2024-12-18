using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BanCaCanh.data;
using BanCaCanh.dto.category;
using BanCaCanh.Interface;
using BanCaCanh.mappers;
using BanCaCanh.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace BanCaCanh.repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<bool> CategoryExists(int id)
        {
            return _context.Categories.AnyAsync(s => s.Id == id);
        }

        public async Task<Category> CreateAsync(Category categoryModel)
        {
            await _context.AddAsync(categoryModel);
            await _context.SaveChangesAsync();
            return categoryModel;
        }

        public async Task<Category?> DeleteAsync(int id)
        {
            var categoryModel = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (categoryModel == null)
            {
                return null;
            }
            _context.Categories.Remove(categoryModel);
            await _context.SaveChangesAsync();
            return categoryModel;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<List<CategoryDto>> GetCategories(int productId)
        {
            var categories = await _context.ProductCategory.Where(p => p.ProductId == productId).Select(pc => new CategoryDto
            {
                Id = pc.Category.Id,
                CategoryName = pc.Category.CategoryName,
            }).ToListAsync();

            return categories;
        }

        public async Task<Category?> UpdateAsync(int id, CreateCategoryDto categoryDto)
        {
            var categoryModel = await _context.Categories.FirstOrDefaultAsync(s => s.Id == id);
            if (categoryModel == null)
            {
                return null;
            }
            categoryModel.CategoryName = categoryDto.CategoryName;
            await _context.SaveChangesAsync();
            return categoryModel;
        }
    }
}