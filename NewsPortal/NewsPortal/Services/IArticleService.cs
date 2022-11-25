using NewsPortal.Model.Request;
using NewsPortal.WebAPI.Model;
using NewsPortal.WebAPI.Services;
using System.Collections.Generic;

namespace NewsPortal.Services
{
   public interface IArticleService 
    {
        public MArticle LikeArticle(int Id);
        public MArticle UnlikeArticle(int Id);
    }
}
