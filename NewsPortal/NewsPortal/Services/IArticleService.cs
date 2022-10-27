using NewsPortal.Model.Request;
using NewsPortal.WebAPI.Model;
using NewsPortal.WebAPI.Services;


namespace NewsPortal.Services
{
   public interface IArticleService 
    {
        public MArticle LikeArticle(int Id);
    }
}
