using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanCaCanh.helper
{
    public class CommentQueryObject
    {
        public int ProductId { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 1;
    }
}