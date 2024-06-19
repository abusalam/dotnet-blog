using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyBlogAPI8.BAL.IServices;
using MyBlogAPI8.Migrations.Entity;
using MyWebAPI8.Models;

namespace MyBlogAPI8.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        IUserService _UserService;
        public UserController(IUserService es) {
            _UserService = es;
        }

        [HttpPost("AddUser")]
        public async Task<int> AddUser(UserModel e) {
            int result = await _UserService.CreateUser(e);
            return result;
        }

        [HttpGet("Users")]
        public async Task<IQueryable<User>> GetUsers() {
            IQueryable<User> result = await _UserService.GetAllUsers();
            return result;
        }

        [HttpGet("UsersAsync")]
        public async Task<ICollection<User>> GetUsersAsync() {
            ICollection<User>? result = await _UserService.GetAllUsersAsync();
            return result;
        }

    }
}