using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BanCaCanh.data;
using BanCaCanh.Interface;
using BanCaCanh.models;

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
    }
}