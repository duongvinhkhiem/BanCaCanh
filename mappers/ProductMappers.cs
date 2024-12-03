using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BanCaCanh.dto.product;
using BanCaCanh.models;

namespace BanCaCanh.mappers
{
    public static class ProductMappers
    {
        public static ProductDto ToProductDto(this Product productModel)
        {
            return new ProductDto
            {
                Id = productModel.Id,
                ProductName = productModel.ProductName,
                Price = productModel.Price,
                Description = productModel.Description,
                IsVisible = productModel.IsVisible,
                CategoryId = productModel.CategoryId,
                StockQuanity = productModel.StockQuanity,
            };
        }
        public static Product ToCreateProductDto(this CreateProductDto productModel, int categoryId)
        {
            return new Product
            {
                ProductName = productModel.ProductName,
                Price = productModel.Price,
                Description = productModel.Description,
                IsVisible = productModel.IsVisible,
                CategoryId = productModel.CategoryId,
                StockQuanity = productModel.StockQuanity,
            };
        }
    }
}