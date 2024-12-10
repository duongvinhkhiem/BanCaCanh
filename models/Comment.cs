using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BanCaCanh.models
{
    [Table("Comments")]
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string AppUserId { get; set; }
        public int ProductId { get; set; }
        public AppUser AppUser { get; set; }
        public Product Product { get; set; }
    }
}