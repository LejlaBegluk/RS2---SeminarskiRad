using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortal.WebAPI.Services
{
    public interface IService<TModel, TSearch> where TModel : class where TSearch : class
    {
        IEnumerable<TModel> Get(TSearch search);

        TModel GetById(int id);
    }
}
