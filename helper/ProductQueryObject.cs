using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanCaCanh.helper
{
    public class ProductQueryObject : PaginationObject
    {
        public int? Categoryid { get; set; } = null;
        public string? Search { get; set; } = null;
    }
}