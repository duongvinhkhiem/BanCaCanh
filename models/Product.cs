using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanCaCanh.models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int StockQuantity { get; set; }
        public bool IsVisible { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public List<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
    }
}