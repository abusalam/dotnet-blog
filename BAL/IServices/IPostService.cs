using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBlogAPI8.Models;

namespace MyBlogAPI8.BAL.IServices
{
    public interface IPostService
    {
        Task<int> CreatePost(PostModel pm);
    }
}