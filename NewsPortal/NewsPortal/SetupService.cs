using Microsoft.EntityFrameworkCore;
using NewsPortal.WebAPI.Database;

namespace NewsPortal
{
    public class SetupService
    {
        public static void Init(PortalDbContext context)
        {
            context.Database.Migrate();
        }
    }
}
