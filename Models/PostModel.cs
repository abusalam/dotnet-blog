using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogAPI8.Models
{
    public class PostModel
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Category { get; set; }
        public bool? IsPublished { get; set; }
    }
}