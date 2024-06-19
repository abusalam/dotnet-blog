using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBlogAPI8.Migrations.Entity;
using MyWebAPI8.Models;

namespace MyBlogAPI8.BAL.IServices
{
    public interface IUserService
    {
        Task<int> CreateUser(UserModel um);
        Task<IQueryable<User>> GetAllUsers();
        Task<ICollection<User>> GetAllUsersAsync();
    }
}