using Microsoft.AspNetCore.Authorization;
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
    public class CRUDController<T, TSearch, TInsert, TUpdate> : BaseController<T, TSearch> where T : class where TSearch : class where TInsert : class where TUpdate : class
    {
        private readonly ICRUDService<T, TSearch, TInsert, TUpdate> _service;
        public CRUDController(ICRUDService<T, TSearch, TInsert, TUpdate> service) : base(service)
        {
            _service = service;
        }
        [HttpPost]
        //[Authorize(Roles = "Admin,Instruktor,Polaznik")]
        public async Task<T> Insert(TInsert request)
        {
            return await _service.Insert(request);
        }
        [HttpPut("{ID}")]
       // [Authorize]
        public async Task<T> Update(int ID, TUpdate request)
        {
            return await _service.Update(ID, request);
        }
        [HttpDelete("{ID}")]
       // [Authorize(Roles = "Admin,Instruktor")]
        public async Task<bool> Delete(int ID)
        {
            return await _service.Delete(ID);
        }
    }
}