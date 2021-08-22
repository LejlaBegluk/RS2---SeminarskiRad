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
    public class PollController : CRUDController<MPoll, PollSearchRequest, PollUpsertRequest, PollUpsertRequest>
    {
        public PollController(ICRUDService<MPoll, PollSearchRequest, PollUpsertRequest, PollUpsertRequest> service) : base(service)
        {

        }
    }
}