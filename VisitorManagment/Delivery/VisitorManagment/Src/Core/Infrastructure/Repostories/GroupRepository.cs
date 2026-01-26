

namespace _4EPlatForm.Infrastrucure.Repostories
{
    public class GroupRepository : GRepository<Group> , IGroupRepository
    {
        public GroupRepository(DBContext context) :base(context) 
        { 
        }    
    }
}
