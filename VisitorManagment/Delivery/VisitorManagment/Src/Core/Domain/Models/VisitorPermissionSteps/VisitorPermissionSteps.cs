namespace _4EPlatform.Domain.Models.VisitorPermissionSteps
{
    public class VisitorPermissionSteps : BaseEntity<Guid>
    {
        public Guid? PermissionId { get; set; }
        public Permission.Permission Permission { get; set; }
        //Descration Logs
        public string? Description { get; set; }
        public string? Reason { get; set; }
        public DateTime? Date { get; set; }
        public Guid? VisitorId { get; set; }
        public Visitor.Visitor Visitor { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public TimeOnly? StartTime { get; set; }
        public TimeOnly? EndTime { get; set; }
        public Guid? UserId { get; set; }
        public string? VisitorName { get; set; }
        public string? Violationtype { get; set; }
        public CanceledReason? ReasonForCancled { get; set; }
        public string? NationalID { get; set; }
        public string? PhoneNumber { get; set; }
        public string? WhatsAppNumber { get; set; }
        public string? Email { get; set; }
        public Guid? OrgId { get; set; }
        public Guid? RecivedId { get; set; }
        public string? Notes { get; set; }
        public List<StepsAttachment> Attachments { get; set; } = new List<StepsAttachment>();
        public PermissionType? PermissionType { get; set; }
        public PermissionStatus? permissionStatus { get; set; }
        public ActionType Action { get; set; }
        public PutStatus? PutStatus { get; set; }

        public Guid? CancelRequestId { get; set; }
        public CancelRequest.CancelRequest? cancelRequest { get; set; }




    }
}
