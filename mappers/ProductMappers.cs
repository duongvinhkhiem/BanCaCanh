using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BanCaCanh.dto;
using BanCaCanh.dto.product;
using BanCaCanh.models;

namespace BanCaCanh.mappers
{
    public static class ProductMappers
    {
        public static ProductDto ToProductDto(this Product productModel, List<ImagesDto> productImage)
        {
            return new ProductDto
            {
                Id = productModel.Id,
                ProductName = productModel.ProductName,
                Price = productModel.Price,
                Description = productModel.Description,
                IsVisible = productModel.IsVisible,
                StockQuantity = productModel.StockQuantity,
                CreatedAt = productModel.CreatedAt,
                ProductImages = productImage,
            };
        }
        public static Product ToCreateProductDto(this CreateProductDto productModel)
        {
            return new Product
            {
                ProductName = productModel.ProductName,
                Price = productModel.Price,
                Description = productModel.Description,
                StockQuantity = productModel.StockQuantity,
            };
        }
        public static ImagesDto ToImagesDto(this ProductImage productImage)
        {
            return new ImagesDto
            {
                Id = productImage.Id,
                ImageUrl = productImage.ImageUrl,
                ProductId = productImage.Id
            };
        }
    }
}