using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BanCaCanh.dto.category;
using BanCaCanh.dto.product_category;
using BanCaCanh.models;

namespace BanCaCanh.Interface
{
    public interface IProductCategory
    {
        Task<bool> ProductCategoryExists(ProductCategoryDto productCategory);
        Task<ProductCategory> CreateAsync(ProductCategory productCategory);
        Task<ProductCategory> DeleteAsync(ProductCategoryDto productCategory);
    }
}