using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BanCaCanh.dto;
using BanCaCanh.models;

namespace BanCaCanh.Interface
{
    public interface IProductImage
    {
        Task<List<ImagesDto>> GetAllAsync(int productId);
        Task<ProductImage> CreateAsync(ProductImage productImage);
    }
}