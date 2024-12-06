using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BanCaCanh.data;
using BanCaCanh.dto;
using BanCaCanh.Interface;
using BanCaCanh.mappers;
using BanCaCanh.models;
using Microsoft.EntityFrameworkCore;

namespace BanCaCanh.repository
{
    public class ProductImageRepository : IProductImage
    {
        private readonly AppDbContext _context;
        public ProductImageRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ProductImage> CreateAsync(ProductImage productImage)
        {
            await _context.ProductImages.AddAsync(productImage);
            await _context.SaveChangesAsync();
            return productImage;
        }

        public async Task<List<ImagesDto>> GetAllAsync(int productId)
        {
            var images = await _context.ProductImages.Where(p => p.ProductId == productId).ToListAsync();
            var imagesDto = images.Select(s => s.ToImagesDto()).ToList();
            return imagesDto;
        }
    }
}