using NewsPortal.WebAPI.Model;
using System.Collections.Generic;

namespace NewsPortal.WebAPI.Services
{
    public interface ICommentService
    {
        public List<MComment> GetByArticleId(int ID);
    }
}
