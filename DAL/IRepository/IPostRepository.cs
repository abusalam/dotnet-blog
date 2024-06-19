using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBlogAPI8.Migrations.Entity;
using MyWebAPI8.DAL.IRepository;

namespace MyBlogAPI8.DAL.IRepository
{
    public interface IPostRepository: IRepository<Post>
    {
        
    }
}