

namespace _4EPlatForm.Infrastrucure.Repostories
{
    public class CancelRequestReposatiry :GRepository<CancelRequest> , ICancelRequestReposatiry

    {
        public CancelRequestReposatiry(DBContext context) : base(context)
        {

        }
    }
}
