using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BanCaCanh.dto.category;
using BanCaCanh.models;

namespace BanCaCanh.dto.product
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal? Price { get; set; }
        public string? Description { get; set; }
        public int? StockQuantity { get; set; }
        public bool IsVisible { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<ImagesDto> ProductImages { get; set; }
        public List<CategoryDto> Categories { get; set; }
    }
}