

namespace _4EPlatform.Domain.Models.Violation
{
    public class Violation : BaseEntity<Guid>
    {
        public string? Violationtype  { get; set; }

        public DateTime Date { get; set; }

        public string? Location { get; set; }

        public string? Description { get; set; }

        public Visitor.Visitor Visitor { get; set; }

        public Guid VisitorId { get; set; }

        public ICollection< CancelRequest.CancelRequest> CancelRequest { get; set; }
        public ICollection<violationAttachment>? Attachments { get; set; } = new HashSet<violationAttachment>();


    }
}
