using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MyBlogAPI8.BAL.IServices;
using MyBlogAPI8.DAL.IRepository;
using MyBlogAPI8.Migrations.Entity;
using MyBlogAPI8.Models;
using static MyWebAPI8.Helper.Enum;

namespace MyBlogAPI8.BAL.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _PostRepo;
        private readonly IMapper _mapper;

        public PostService(IPostRepository emrepo, IMapper mapper){
            _PostRepo = emrepo;
            _mapper = mapper;
        }
        public async Task<int> CreatePost(PostModel em) {
            Post? newPost = _mapper.Map<Post>(em);
            newPost.Category = (int) PostCategoryEnum.Health;
            newPost.CreatedDate = DateTime.Now;
            if(_PostRepo.Add(newPost)){
                _PostRepo.SaveChangesManaged();
            }
            return newPost.Id;
        }
    }
}