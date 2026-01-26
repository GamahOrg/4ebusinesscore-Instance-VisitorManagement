namespace _4EPlatform.Domain.Models.VisitorPermissionSteps
{
    public class StepsAttachment : BaseEntity<Guid>
    {
        public string? FilePath { get; set; }
        public string? FileName { get; set; }
        public Guid VisitorPermissionStepsId { get; set; }
        public VisitorPermissionSteps VisitorPermissionSteps { get; set; }
    }
}
