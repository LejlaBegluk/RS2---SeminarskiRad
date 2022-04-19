using NewsPortal.Model.Request;
using NewsPortal.WebAPI.Model;

namespace NewsPortal.WebAPI.Services
{
    public interface IUserRoleService : ICRUDService<MUserRole, UserRoleSearchRequest, UserRoleUpsertRequest, UserRoleUpsertRequest>
    {
    }
}
