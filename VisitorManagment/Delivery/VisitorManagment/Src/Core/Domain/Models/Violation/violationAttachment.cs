

namespace _4EPlatform.Domain.Models.Violation
{
    public class violationAttachment :BaseEntity<Guid>
    {
        public string? FilePath { get; set; }
        public string? FileName { get; set; }
        public Guid ViolationId { get; set; }
        public Violation Voilation { get; set; }
    }
}
