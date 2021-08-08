using NewsPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortal.Services
{
   public interface IArticleService
    {
        public IEnumerable<Article> Get();
        public Article GetById(int Id);
    }
}
