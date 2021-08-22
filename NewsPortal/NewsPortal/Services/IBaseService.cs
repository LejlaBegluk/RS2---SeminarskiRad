using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortal.WebAPI.Services
{
    public interface IBaseService<T, TSearch>
    {
        Task<List<T>> Get(TSearch search);
        Task<T> GetById(int ID);

    }
}