using Microsoft.VisualStudio.Services.Users;
using NewsPortal.Model.Request;
using NewsPortal.WebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortal.WebAPI.Services
{
    public interface IUserService : ICRUDService<MUser, UserSearchRequest, UserUpsertRequest, UserUpsertRequest>
    {
        Task<MUser> Authenticate(string Username, string Password);
        Task<MUser> Register(UserRegisterRequest request);
        public Task<MUser> EditProfile(UserEditProfileRequest request);


    }
}