using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BanCaCanh.data;
using BanCaCanh.dto.product_category;
using BanCaCanh.Interface;
using BanCaCanh.models;
using Microsoft.EntityFrameworkCore;

namespace BanCaCanh.repository
{
    public class ProductCategoryRepository : IProductCategory
    {
        private readonly AppDbContext _context;
        public ProductCategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ProductCategory> CreateAsync(ProductCategory productCategory)
        {
            await _context.ProductCategory.AddAsync(productCategory);
            await _context.SaveChangesAsync();
            return productCategory;
        }

        public async Task<ProductCategory> DeleteAsync(ProductCategoryDto productCategory)
        {
            var model = await _context.ProductCategory.FirstOrDefaultAsync(p => p.ProductId == productCategory.ProductId && p.CategoryId == productCategory.CategoryId);
            _context.ProductCategory.Remove(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<bool> ProductCategoryExists(ProductCategoryDto productCategory)
        {
            return await _context.ProductCategory
                .AnyAsync(pc => pc.ProductId == productCategory.ProductId && pc.CategoryId == productCategory.CategoryId);
        }

    }
}