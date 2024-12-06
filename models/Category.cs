using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BanCaCanh.models
{
    [Table("Categories")]
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public List<ProductCategory> ProductCategory { get; set; } = new List<ProductCategory>();
    }
}