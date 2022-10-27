using Microsoft.AspNetCore.Mvc;
using NewsPortal.Model.Request;
using NewsPortal.WebAPI.Model;
using NewsPortal.WebAPI.Services;

namespace NewsPortal.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaidArticleController : CRUDController<MPaidArticle, PaidArticleSearchRequest, PaidArticleUpsertRequest, PaidArticleUpsertRequest>
    {
        protected readonly IPaidArticleService _service;
        public PaidArticleController(ICRUDService<MPaidArticle, PaidArticleSearchRequest, PaidArticleUpsertRequest, PaidArticleUpsertRequest> service, IPaidArticleService articleService) : base(service)
        {
            _service = articleService;
        }
    }
}
