

namespace _4EPlatform.Domain.Models.CheckIn_OutVisitor
{
    public class CheckIn_OutVisitor:BaseEntity<Guid>
    {
        public DateTime Date { get; set; }
        public TransitStatus TransitStatus { get; set; }
        public bool ISTransit { get; set; }
        public string? TransitComment { get; set; }

        public Visitor.Visitor Visitor { get; set; }
        public Guid VisitorId { get; set; }
    }
}
