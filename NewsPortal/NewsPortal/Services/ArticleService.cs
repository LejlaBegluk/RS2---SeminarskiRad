using NewsPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortal.Services
{
    public class ArticleService:IArticleService
    {
        List<Article> list = new List<Article>()
            {
             new Article()
             {
                 Id=new int(),
                 Title="Naslov članka 1"
             },
              new Article()
             {
                 Id=new int(),
                 Title="Naslov članka 2"
             }
            };

        public IEnumerable<Article> Get()
        {
            return list;
        }
        public Article GetById(int Id)
        {
            return new Article()
            {
                Id = new int(),
                Title = $"Naslov članka {Id}"
            };
        }
    }
}
