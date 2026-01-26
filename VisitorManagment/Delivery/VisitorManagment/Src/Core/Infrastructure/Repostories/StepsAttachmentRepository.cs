namespace _4EPlatForm.Infrastrucure.Repostories
{
    public class StepsAttachmentRepository : GRepository<StepsAttachment>, IStepsAttachmentRepository
    {
        public StepsAttachmentRepository(DBContext context) : base(context)
        {

        }
    }
}
