

namespace _4EPlatForm.Infrastrucure.Repostories
{
    public class PermissionRepository : GRepository<Permission>, IPermissionRepository
    {
        public PermissionRepository(DBContext context) : base(context)
        {

        }
    }
}
