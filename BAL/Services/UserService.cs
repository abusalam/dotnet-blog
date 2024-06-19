using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MyBlogAPI8.BAL.IServices;
using MyBlogAPI8.DAL.IRepository;
using MyBlogAPI8.Migrations.Entity;
using MyWebAPI8.Models;

namespace MyBlogAPI8.BAL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _UserRepo;
        private readonly IMapper _mapper;

        public UserService(IUserRepository emrepo, IMapper mapper){
            _UserRepo = emrepo;
            _mapper = mapper;
        }
        public async Task<int> CreateUser(UserModel em) {
            User? newUser = _mapper.Map<User>(em);
            if(_UserRepo.Add(newUser)){
                _UserRepo.SaveChangesManaged();
            }
            return newUser.Id;
        }

        public async Task<IQueryable<User>> GetAllUsers()
        {
            IQueryable<User> result = this._UserRepo.GetAll();
            return result;
        }

        public Task<ICollection<User>> GetAllUsersAsync()
        {
            Task<ICollection<User>>? result = this._UserRepo.GetAllAsync();
            return result;
        }
    }
}