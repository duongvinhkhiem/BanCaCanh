using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BanCaCanh.data;
using BanCaCanh.dto.category;
using BanCaCanh.Interface;
using BanCaCanh.models;
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