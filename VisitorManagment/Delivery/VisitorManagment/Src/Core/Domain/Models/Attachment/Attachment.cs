namespace _4EPlatform.Domain.Models.Attachment
{
    public class Attachment : BaseEntity<Guid>
    {
        public string? FilePath { get; set; }
        public string? FileName { get; set; }
        public AttachmentPosition? AttachmentPosition { get; set; }
        public Guid PermissionId { get; set; }
        public Permission.Permission Permission { get; set; }

    }
}
