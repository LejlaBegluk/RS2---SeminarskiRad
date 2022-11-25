using Microsoft.AspNetCore.Mvc;
using NewsPortal.Model.Request;
using NewsPortal.WebAPI.Database;
using NewsPortal.WebAPI.Model;
using NewsPortal.WebAPI.Services;

namespace NewsPortal.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaidArticleStatusController : CRUDController<MPaidArticleStatus, PaidArticleStatusSearchRequest, PaidArticleStatusUpsertRequest, PaidArticleStatusUpsertRequest>
    {
        public PaidArticleStatusController(ICRUDService<MPaidArticleStatus, PaidArticleStatusSearchRequest, PaidArticleStatusUpsertRequest, PaidArticleStatusUpsertRequest> service) : base(service)
        {

        }
    }
}