using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanCaCanh.helper
{
    public class QueryObject
    {
        public int? Categoryid { get; set; } = null;
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 1;

    }
}