

namespace _4EPlatForm.Infrastrucure.Repostories
{
    public class ViolationReopsatiry :GRepository<Violation> , IViolationReposatiry
    {
        public ViolationReopsatiry(DBContext context) : base(context)
        {

        }
    }
}
