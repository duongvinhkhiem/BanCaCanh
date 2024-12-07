using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BanCaCanh.models;

namespace BanCaCanh.Interface
{
    public interface IProductCategory
    {
        Task<ProductCategory> CreateAsync(ProductCategory productCategory);
    }
}