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

        public IQueryable<UserModel> GetAllUsers()
        {
            IQueryable<UserModel> result = _mapper.Map<IQueryable<UserModel>>(this._UserRepo.GetAll());
            return result;
        }

        public async Task<ICollection<UserModel>> GetAllUsersAsync()
        {
            ICollection<UserModel>? result = _mapper.Map<ICollection<UserModel>>( await this._UserRepo.GetAllAsync());
            return result;
        }
    }
}