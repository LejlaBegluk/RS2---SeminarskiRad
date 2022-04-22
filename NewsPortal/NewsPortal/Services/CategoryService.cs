using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Services.Users;
using NewsPortal.Model.Request;
using NewsPortal.WebAPI.Database;
using NewsPortal.WebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortal.WebAPI.Services
{
    public class CategoryService : CRUDService<MCategory, CategorySearchRequest, Category, CategoryUpsertRequest, CategoryUpsertRequest>, ICategoryService
    {
        private readonly PortalDbContext _context;
        private readonly IMapper _mapper;
        public CategoryService(PortalDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public override IEnumerable<MCategory> Get(CategorySearchRequest request)
        {
            var query = _context.Categories.AsQueryable().OrderBy(c => c.Name);

            if (!string.IsNullOrWhiteSpace(request?.Name))
            {
                query = query.Where(x => x.Name.StartsWith(request.Name)).OrderBy(c => c.Name);
            }
            var list =  query.ToList();

            return _mapper.Map<IEnumerable<MCategory>>(list);
        }
        public override MCategory GetById(int ID)
        {
            var entity =  _context.Categories
                .Where(i => i.Id == ID)
                .SingleOrDefault();

            return _mapper.Map<MCategory>(entity);
        }
       public override async Task<MCategory> Insert(CategoryUpsertRequest request)
        {
            if (await _context.Categories.AnyAsync(i => i.Name == request.Name))
            {
                throw new UserException("Category with that name already exists!");
            }

            var entity = _mapper.Map<Category>(request);
            entity.CreateOn = DateTime.Now;
            _context.Set<Category>().Add(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<MCategory>(entity);
        }
        public override async Task<MCategory> Update(int ID, CategoryUpsertRequest request)
        {
            var category = await _context.Categories.FindAsync(ID);
            if (await _context.Categories.AnyAsync(i => i.Name == request.Name) && request.Name != category.Name)
            {
                throw new UserException("Category with that name already exists!");
            }

            var entity = _context.Set<Category>().Find(ID);
            entity.UpdatedOn = DateTime.Now;
            _context.Set<Category>().Attach(entity);
            _context.Set<Category>().Update(entity);

            _mapper.Map(request, entity);

            await _context.SaveChangesAsync();

            return _mapper.Map<MCategory>(entity);
        }
        public override async Task<bool> Delete(int ID)
        {
            var category = await _context.Categories.Where(i => i.Id == ID).FirstOrDefaultAsync();
            if (category != null) {
            var articleList = await _context.Articles.Where(i => i.CategoryId == ID).ToListAsync();

            if (!articleList.Any())
            {
               _context.Categories.Remove(category);
               await _context.SaveChangesAsync();
                return true;
            }
         }
            return false;
        }
    }
}