using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using MyBlogAPI8.BAL.IServices;
using MyBlogAPI8.Common;
using MyBlogAPI8.Migrations.Entity;
using MyWebAPI8.Models;
using static MyWebAPI8.Helper.Enum;

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
        public ApiResponse<IQueryable<UserModel>> GetUsers() {
            ApiResponse<IQueryable<UserModel>> result = new ApiResponse<IQueryable<UserModel>>();
            try {
                result.data = _UserService.GetAllUsers();
                result.apiResponseStatus = APIResponseStatus.Success;
            }
            catch (Exception e) {
                result.apiResponseStatus = APIResponseStatus.Error;
                result.ErrorMessage = "Error: " + e.Message;
            }
            return result;
        }

        [HttpGet("UsersAsync")]
        public async Task<ApiResponse<ICollection<UserModel>>> GetUsersAsync() {
            ApiResponse<ICollection<UserModel>>? result = new ApiResponse<ICollection<UserModel>>();
            try {
                result.data = await _UserService.GetAllUsersAsync();
                result.apiResponseStatus = APIResponseStatus.Success;
            }
            catch (Exception e) {
                result.apiResponseStatus = APIResponseStatus.Error;
                result.ErrorMessage = "Error: " + e.Message;
            }
            return result;
        }

    }
}