using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewsPortal.Model.Request;
using NewsPortal.WebAPI.Model;
using NewsPortal.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : CRUDController<MUser, UserSearchRequest, UserUpsertRequest, UserUpsertRequest>
    {
        private readonly IUserService _service;
        public UserController(IUserService service) : base(service)
        {
            _service = service;
        }
        [HttpGet("Authenticate")]
        [AllowAnonymous]
        public async Task<MUser> Authenticate()
        {
            try { 
            string authorization = HttpContext.Request.Headers["Authorization"];

            string encodedHeader = authorization["Basic ".Length..].Trim();

            Encoding encoding = Encoding.GetEncoding("iso-8859-1");
            string usernamePassword = encoding.GetString(Convert.FromBase64String(encodedHeader));

            int seperatorIndex = usernamePassword.IndexOf(':');

            return await _service.Authenticate(usernamePassword.Substring(0, seperatorIndex), usernamePassword[(seperatorIndex + 1)..]);
            }
            catch(Exception ex)
            {

            }
            return null;
        }
        [HttpPost("Register")]
        public async Task<MUser> Register(UserRegisterRequest request)
        {
            return await _service.Register(request);
        }
        [HttpPost("EditProfile")]
        public async Task<MUser> EditProfile(UserEditProfileRequest request)
        {
            return await _service.EditProfile(request);
        }


    }
}
