using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BanCaCanh.data;
using BanCaCanh.dto.product;
using BanCaCanh.helper;
using BanCaCanh.Interface;
using BanCaCanh.models;
using Microsoft.EntityFrameworkCore;

namespace BanCaCanh.repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateAsync(Product productModel)
        {
            await _context.Products.AddAsync(productModel);
            await _context.SaveChangesAsync();
            return productModel;
        }

        public async Task<Product?> DeleteAsync(int id)
        {
            var productModel = await _context.Products.FirstOrDefaultAsync(s => s.Id == id);
            if (productModel == null)
            {
                return null;
            }
            productModel.IsVisible = false;
            await _context.SaveChangesAsync();
            return productModel;
        }

        public async Task<List<Product>> GetAllAsync(ProductQueryObject queryObject)
        {
            var products = _context.Products.Where(s => s.IsVisible == true);
            var skip = (queryObject.Page - 1) * queryObject.PageSize;
            if (queryObject.Categoryid != null)
            {
                products = products.Where(p => p.ProductCategory.Any(pc => pc.CategoryId == queryObject.Categoryid));
            }
            var list = await products.OrderByDescending(p => p.CreatedAt).Skip(skip).Take(queryObject.PageSize).ToListAsync();
            return list;
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product?> UpdateAsync(int id, UpdateProductDto productDto)
        {
            var productModel = await _context.Products.FirstOrDefaultAsync(s => s.Id == id);
            if (productModel == null)
            {
                return null;
            }
            productModel.ProductName = productDto.ProductName;
            productModel.Description = productDto.Description;
            productModel.StockQuantity = productDto.StockQuantity;
            productModel.Price = productDto.Price;
            await _context.SaveChangesAsync();
            return productModel;
        }
    }
}