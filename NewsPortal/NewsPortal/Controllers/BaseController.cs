using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsPortal.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortal.WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class BaseController<T, Tsearch> : ControllerBase where T : class where Tsearch : class
    {
        private readonly IService<T, Tsearch> _service;
        public BaseController(IService<T, Tsearch> service)
        {
            _service = service;
        }
        [HttpGet]
        [AllowAnonymous]
        public virtual IEnumerable<T> Get([FromQuery] Tsearch search = null)
        {
            return _service.Get(search);
        }
        [HttpGet("{id}")]
        [AllowAnonymous]
        public virtual T GetById(int id)
        {
            return _service.GetById(id);
        }
    }
}