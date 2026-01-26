
namespace _4EPlatForm.Infrastrucure.Repostories
{
    public class VisitorRepository : GRepository<Visitor> , IVisitorRepository
    {

        public VisitorRepository(DBContext context) : base(context)
        {

        }
    }
}
