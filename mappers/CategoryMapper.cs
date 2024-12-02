using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BanCaCanh.dto.category;
using BanCaCanh.models;

namespace BanCaCanh.mappers
{
    public static class CategoryMapper
    {
        public static CategoryDto ToCategoryDto(this Category categoryModel)
        {
            return new CategoryDto
            {
                Id = categoryModel.Id,
                CategoryName = categoryModel.CategoryName
            };
        }
        public static Category ToCreateCategoryDto(this CreateCategoryDto categoryDto)
        {
            return new Category
            {
                CategoryName = categoryDto.CategoryName
            };
        }
    }
}