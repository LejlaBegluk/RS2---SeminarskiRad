using Microsoft.AspNetCore.Authorization;
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
    [AllowAnonymous]
    public class PollAnswerController : CRUDController<MPollAnswer, PollAnswerSearchRequest, PollAnswerUpsertRequest, PollAnswerUpsertRequest>
    {
        protected readonly IPollAnswerService _service;

        public PollAnswerController(ICRUDService<MPollAnswer, PollAnswerSearchRequest, PollAnswerUpsertRequest, PollAnswerUpsertRequest> service, IPollAnswerService answerService) : base(service)
        {
             _service=answerService;
        }
        [HttpGet("Vote")]
        public Task<int> Vote(int Id)
        {
            return _service.Vote(Id);
        }
        [HttpGet("Results")]
        public Task<IEnumerable<PollResultsRequest>> Results(int Id)
        {
            return _service.Results(Id);
        }
    }
}