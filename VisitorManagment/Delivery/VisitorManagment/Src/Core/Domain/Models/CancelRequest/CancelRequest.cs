

namespace _4EPlatform.Domain.Models.CancelRequest
{
    public class CancelRequest : BaseEntity<Guid>
    {
        public CanceledReason ReasonForCancled {  get; set; }
        
        public CancelRequestStatus status { get; set; }

        public string? reason { get; set; }

        public Guid? ViolationId { get; set; }
        public Violation.Violation Violation { get; set; }

        public Guid VisitorId { get; set; }
        public Visitor.Visitor Visitor { get; set; }

        public List<VisitorPermissionSteps.VisitorPermissionSteps> VisitorPermissionSteps { get; set; } 


    }
}
