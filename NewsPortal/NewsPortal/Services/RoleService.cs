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
    public class RoleService : CRUDService<MRole, RoleSearchRequest, Role, RoleUpsertRequest, RoleUpsertRequest>
    {
        private readonly PortalDbContext _context;
        private readonly IMapper _mapper;
        public RoleService(PortalDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public override async Task<List<MRole>> Get(RoleSearchRequest request)
        {
            var query = _context.Roles.AsQueryable().OrderBy(c => c.Id);

            if (request?.RoleId != 0)
            {
                query = query.Where(x => x.Id == request.RoleId).OrderBy(c => c.Id);
            }
            var list = await query.ToListAsync();

            return _mapper.Map<List<MRole>>(list);
        }
        public override async Task<MRole> GetById(int ID)
        {
            var entity = await _context.Roles
                .Where(i => i.Id == ID)
                .SingleOrDefaultAsync();

            return _mapper.Map<MRole>(entity);
        }
        public override async Task<MRole> Insert(RoleUpsertRequest request)
        {
            if (await _context.Roles.AnyAsync(i => i.Name == request.Name && request.Description != request.Description))
            {
                throw new UserException("Role with that name already exists!");
            }

            var entity = _mapper.Map<Role>(request);

            _context.Set<Role>().Add(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<MRole>(entity);
        }
        public override async Task<MRole> Update(int ID, RoleUpsertRequest request)
        {
            var Role = await _context.Roles.FindAsync(ID);
            if (await _context.Roles.AnyAsync(i => i.Name == request.Name && request.Description != request.Description))
            {
                throw new UserException("Role with that question already exists!");
            }

            var entity = _context.Set<Role>().Find(ID);
            _context.Set<Role>().Attach(entity);
            _context.Set<Role>().Update(entity);

            _mapper.Map(request, entity);

            await _context.SaveChangesAsync();

            return _mapper.Map<MRole>(entity);
        }
        public override async Task<bool> Delete(int ID)
        {
            var Role = await _context.Roles.Where(i => i.Id == ID).FirstOrDefaultAsync();
            if (Role != null)
            {

                _context.Roles.Remove(Role);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}