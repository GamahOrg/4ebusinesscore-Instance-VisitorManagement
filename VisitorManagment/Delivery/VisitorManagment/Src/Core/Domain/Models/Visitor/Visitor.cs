namespace _4EPlatform.Domain.Models.Visitor
{
    public class Visitor : BaseEntity<Guid>
    {
        public Guid? UserId { get; set; }
        public Guid? ManagerId { get; set; }
        public string? VisitorName { get; set; }
        public string? NationalID { get; set; }
        public string? PhoneNumber { get; set; }
        public string? WhatsAppNumber { get; set; }
        public string? Email { get; set; }
        public PermissionStatus permissionStatus { get; set; }
        public bool IsFavorite { get; set; }
        public bool IsArchived { get; set; }
        public Guid? GroupId { get; set; }
        public Group.Group Group { get; set; }
        public Actions? Actions  { get; set; }
        public Guid? PermissionId { get; set; }
        public int VisitorCode { get; set; }
        public Permission.Permission Permission { get; set; }
        public DateOnly? NewStartDate { get; set; }
        public DateOnly? NewEndDate { get; set; }
        public TimeOnly? NewStartTime { get; set; }
        public TimeOnly? NewEndTime { get; set; }
        public List<VisitorPermissionSteps.VisitorPermissionSteps> VisitorPermissionSteps { get; set; } = new List<VisitorPermissionSteps.VisitorPermissionSteps>();
        public List<Violation.Violation> violations { get; set; } = new List<Violation.Violation>();
        public List<CheckIn_OutVisitor.CheckIn_OutVisitor> CheckIn_OutVisitor { get; set; } = new List<CheckIn_OutVisitor.CheckIn_OutVisitor>();

        public List<CancelRequest.CancelRequest> CancelRequestss { get; set; } =new List<CancelRequest.CancelRequest>();
    }
}
