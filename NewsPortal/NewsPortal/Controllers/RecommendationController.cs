using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using NewsPortal.Model.Request;
using NewsPortal.WebAPI.Model;
using NewsPortal.WebAPI.Services;

namespace NewsPortal.WebAPI.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    [RequestSizeLimit(400000000000)]
    public class RecommendationController : CRUDController<MArticle, RecommendationArticleSearchRequest, RecommendationArticleUpsertRequest, RecommendationArticleUpsertRequest>
    {

        public RecommendationController(ICRUDService<MArticle, RecommendationArticleSearchRequest, RecommendationArticleUpsertRequest, RecommendationArticleUpsertRequest> service) : base(service)
        {
  
        }
    }
}
