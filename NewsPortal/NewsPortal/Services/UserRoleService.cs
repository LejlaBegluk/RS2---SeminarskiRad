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
    public class UserRoleService : CRUDService<MUserRole, UserRoleSearchRequest, UserRole, UserRoleUpsertRequest, UserRoleUpsertRequest>
    {
        private readonly PortalDbContext _context;
        private readonly IMapper _mapper;
        public UserRoleService(PortalDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public override async Task<List<MUserRole>> Get(UserRoleSearchRequest request)
        {
            var query = _context.UserRoles.AsQueryable().OrderBy(c => c.RoleId);

            if (request?.UserId != 0)
            {
                query = query.Where(x => x.UserId == request.UserId).OrderBy(c => c.RoleId);
            }
            var list = await query.ToListAsync();

            return _mapper.Map<List<MUserRole>>(list);
        }
        public override async Task<MUserRole> GetById(int ID)
        {
            var entity = await _context.UserRoles
                .Where(i => i.Id == ID)
                .SingleOrDefaultAsync();

            return _mapper.Map<MUserRole>(entity);
        }
        public override async Task<MUserRole> Insert(UserRoleUpsertRequest request)
        {
            if (await _context.UserRoles.AnyAsync(i => i.RoleId == request.RoleId && request.UserId != request.UserId))
            {
                throw new UserException("UserRole with that name already exists!");
            }

            var entity = _mapper.Map<UserRole>(request);
            entity.CreateOn = DateTime.Now;
            entity.UserId = 1;//**********get logged user
            _context.Set<UserRole>().Add(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<MUserRole>(entity);
        }
        public override async Task<MUserRole> Update(int ID, UserRoleUpsertRequest request)
        {
            var UserRole = await _context.UserRoles.FindAsync(ID);
            if (await _context.UserRoles.AnyAsync(i => i.RoleId == request.RoleId && request.UserId != UserRole.UserId))
            {
                throw new UserException("UserRole with that question already exists!");
            }

            var entity = _context.Set<UserRole>().Find(ID);
            _context.Set<UserRole>().Attach(entity);
            _context.Set<UserRole>().Update(entity);

            _mapper.Map(request, entity);

            await _context.SaveChangesAsync();

            return _mapper.Map<MUserRole>(entity);
        }
        public override async Task<bool> Delete(int ID)
        {
            var UserRole = await _context.UserRoles.Where(i => i.Id == ID).FirstOrDefaultAsync();
            if (UserRole != null)
            {
           
                    _context.UserRoles.Remove(UserRole);
                    await _context.SaveChangesAsync();
                    return true;
            }
            return false;
        }
    }
}