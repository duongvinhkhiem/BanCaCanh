using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BanCaCanh.dto.category;
using BanCaCanh.dto.product;

namespace BanCaCanh.dto.product_controller
{
    public class ProductCategoryDto
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
    }
}