using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewsPortal.Model.Request;
using NewsPortal.Models;
using NewsPortal.Services;
using NewsPortal.WebAPI.Controllers;
using NewsPortal.WebAPI.Model;
using NewsPortal.WebAPI.Services;

namespace NewsPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [RequestSizeLimit(400000000000)]
    public class ArticleController : CRUDController<MArticle, ArticleSearchRequest, ArticleUpsertRequest, ArticleUpsertRequest>
    {
        protected readonly IArticleService _service;
        public ArticleController(ICRUDService<MArticle, ArticleSearchRequest, ArticleUpsertRequest, ArticleUpsertRequest> service, IArticleService articleService) : base(service)
        {
            _service = articleService;
        }

        [HttpGet("ArticleLike")]
        [AllowAnonymous]
        public MArticle LikeArticle(int Id)
        {
            return _service.LikeArticle(Id);
        }
        [HttpGet("ArticleUnlike")]
        [AllowAnonymous]
        public MArticle UnikeArticle(int Id)
        {
            return _service.UnlikeArticle(Id);
        }
      

    }
}