using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BanCaCanh.helper
{
    public class CommentQueryObject : PaginationObject
    {
        public int ProductId { get; set; }
    }
}