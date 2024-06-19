using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyBlogAPI8.BAL.IServices;
using MyBlogAPI8.Models;

namespace MyBlogAPI8.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        IPostService _PostService;
        public PostController(IPostService es) {
            _PostService = es;
        }

        [HttpPost("AddPost")]
        public async Task<int> AddPost(PostModel e) {
            int result = await _PostService.CreatePost(e);
            return result;
        }

    }
}