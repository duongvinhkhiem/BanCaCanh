using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BanCaCanh.dto.product;
using BanCaCanh.helper;
using BanCaCanh.models;

namespace BanCaCanh.Interface
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync(ProductQueryObject queryObject);
        Task<Product?> GetByIdAsync(int id);
        Task<Product> CreateAsync(Product productModel);
        Task<Product?> UpdateAsync(int id, UpdateProductDto productDto);
        Task<Product?> DeleteAsync(int id);
    }
}