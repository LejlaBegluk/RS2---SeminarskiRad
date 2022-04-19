using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortal.WebAPI.Services
{
    public interface ICRUDService<T, TSearch, TInsert, TUpdate> : IService<T, TSearch> where T : class where TSearch : class
    {
        Task<T> Insert(TInsert request);
        Task<T> Update(int ID, TUpdate request);
        Task<bool> Delete(int ID);
    }

}