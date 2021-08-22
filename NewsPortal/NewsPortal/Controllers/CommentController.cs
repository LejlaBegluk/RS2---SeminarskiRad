using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsPortal.Model.Request;
using NewsPortal.WebAPI.Database;
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
    public class CommentController : CRUDController<MComment, CommentSearchRequest,  CommentUpsertRequest, CommentUpsertRequest>
    {
        public CommentController(ICRUDService<MComment, CommentSearchRequest,  CommentUpsertRequest, CommentUpsertRequest> service) : base(service)
        {

        }
    }
}