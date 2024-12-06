using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanCaCanh.dto
{
    public class ImagesDto
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public int? ProductId { get; set; }
    }
}