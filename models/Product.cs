using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BanCaCanh.models
{
    [Table("Products")]
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal? Price { get; set; }
        public string? Description { get; set; }
        public int? StockQuantity { get; set; }
        public bool IsVisible { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public List<ProductCategory> ProductCategory { get; set; } = new List<ProductCategory>();
        public List<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}