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
    public class PollAnswerController : CRUDController<MPollAnswer, PollAnswerSearchRequest, PollAnswerUpsertRequest, PollAnswerUpsertRequest>
    {
        public PollAnswerController(ICRUDService<MPollAnswer, PollAnswerSearchRequest, PollAnswerUpsertRequest, PollAnswerUpsertRequest> service) : base(service)
        {

        }
    }
}