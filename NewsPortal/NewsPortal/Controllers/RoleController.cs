using Microsoft.AspNetCore.Http;
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
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : CRUDController<MRole, RoleSearchRequest, RoleUpsertRequest, RoleUpsertRequest>
    {
        public RoleController(ICRUDService<MRole, RoleSearchRequest, RoleUpsertRequest, RoleUpsertRequest> service) : base(service)
        {

        }
    }
}