

namespace _4EPlatForm.Infrastrucure.Repostories
{
    public class VisitorPermissionStepsRepository :GRepository<VisitorPermissionSteps> ,IVisitorPermissionStepsRepository
    {
        public VisitorPermissionStepsRepository(DBContext context) :base(context) { }
    }
}
