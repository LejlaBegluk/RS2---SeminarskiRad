using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewsPortal.Model.Request;
using NewsPortal.WebAPI.Model;
using NewsPortal.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortal.WebAPI.Controllers
{
    public class UserController : CRUDController<MUser, UserSearchRequest, UserUpsertRequest, UserUpsertRequest>
    {
        private readonly IUserService _service;
        public UserController(IUserService service) : base(service)
        {
            _service = service;
        }
        [HttpPost("Authenticate")]
        [AllowAnonymous]
        public async Task<MUser> Authenticate(UserAuthenticationRequest request)
        {
            return await _service.Authenticate(request);
        }
        [HttpPost("Register")]
        public async Task<MUser> Register(UserUpsertRequest request)
        {
            return await _service.Insert(request);
        }

       
    }
}
