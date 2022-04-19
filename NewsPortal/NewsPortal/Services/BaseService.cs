using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NewsPortal.Model.Request;
using NewsPortal.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortal.WebAPI.Services
{
    public class BaseService<TModel, TSearch, TDatabase> : IService<TModel, TSearch> where TModel : class where TDatabase : class where TSearch : BaseSearchObject
    {
        public PortalDbContext _context;
        public IMapper _mapper;
        public BaseService(PortalDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //public List<TModel> Get(TSearch search)
        //{
        //    var list = _context.Set<TDatabase>().ToListAsync();
        //    return _mapper.Map<List<TModel>>(list);
        //}
        //public virtual async Task<TModel> GetById(int ID)
        //{
        //    var entity = await _context.Set<TDatabase>().FindAsync(ID);
        //    return _mapper.Map<TModel>(entity);
        //}

        public virtual IEnumerable<TModel> Get(TSearch search = null)
        {
            var entity = _context.Set<TDatabase>().AsQueryable();

            entity = AddFilter(entity, search);

            if (search?.Page.HasValue == true && search?.PageSize.HasValue == true)
            {
                entity = entity.Take(search.PageSize.Value).Skip(search.Page.Value * search.PageSize.Value);
            }

            var list = entity.ToList();
            //NOTE: elaborate IEnumerable vs IList
            return _mapper.Map<IEnumerable<TModel>>(list);
        }

        public virtual IQueryable<TDatabase> AddFilter(IQueryable<TDatabase> query, TSearch search = null)
        {
            return query;
        }

        public virtual TModel GetById(int id)
        {
            var set = _context.Set<TDatabase>();

            var entity = set.Find(id);

            return _mapper.Map<TModel>(entity);
        }

      
    }

}