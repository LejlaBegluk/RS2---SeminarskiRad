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
    public class UserRoleController : CRUDController<MUserRole, UserRoleSearchRequest, UserRoleUpsertRequest, UserRoleUpsertRequest>
    {
        public UserRoleController(ICRUDService<MUserRole, UserRoleSearchRequest, UserRoleUpsertRequest, UserRoleUpsertRequest> service) : base(service)
        {

        }
    }
}