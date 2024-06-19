using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBlogAPI8.DAL.IRepository;
using MyBlogAPI8.Migrations.DBContext;
using MyBlogAPI8.Migrations.Entity;
using MyWebAPI8.DAL.Repository;

namespace MyBlogAPI8.DAL.Repository
{
    public class PostRepository: Repository<Post, MyBlogContext>, IPostRepository
    {
        public PostRepository(MyBlogContext context) : base (context){
            
        }
    }
}