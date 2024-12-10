using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanCaCanh.dto.comment
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int ProductId { get; set; }
        public string Username { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
    }
}