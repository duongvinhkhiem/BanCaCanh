using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BanCaCanh.helper
{
    public class CommentQueryObject
    {
        public int ProductId { get; set; }
        [Range(1, Int32.MaxValue)]
        public int Page { get; set; } = 1;
        [Range(1, 30)]
        public int PageSize { get; set; } = 1;
    }
}