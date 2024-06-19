using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MyBlogAPI8.Migrations.Entity;
using MyBlogAPI8.Models;
using MyWebAPI8.Models;

namespace MyBlogAPI8.Helper
{
    public class MappingConfig : Profile
    {
        public MappingConfig(){
            CreateMap<UserModel, User>().ReverseMap();
            CreateMap<PostModel, Post>().ReverseMap();
        }
    }
}