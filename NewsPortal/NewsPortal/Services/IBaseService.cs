using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortal.WebAPI.Services
{
    public interface IBaseService<T, TSearch>
    {
        IEnumerable<T> Get(TSearch search);
       T GetById(int ID);

    }
}