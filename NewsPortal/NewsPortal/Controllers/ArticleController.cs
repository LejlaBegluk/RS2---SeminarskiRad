using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewsPortal.Models;
using NewsPortal.Services;

namespace NewsPortal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticleController : ControllerBase
    {
        public IArticleService _articleService { get; set; }

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }
        [HttpGet]
        public IEnumerable<Article> Get()
        {
            return _articleService.Get();
        }
        [HttpGet(template: "{Id}")]
        public Article GetById( int Id)
        {
            return _articleService.GetById(Id);
        }
    }
}