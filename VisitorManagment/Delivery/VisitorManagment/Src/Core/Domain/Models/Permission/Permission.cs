

namespace _4EPlatform.Domain.Models.Permission
{
    public class Permission :BaseEntity<Guid>
    {
        public int PermissionCode { get; set; }
       //public PermissionType PermissionType { get; set; }
       // public PermissionSource PermissionSource { get; set; }
        public Guid OrgId { get; set; }
        public Guid? RecivedId { get; set; }
        public Guid? ManagerId { get; set; }
        public string? PermissionReason { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public bool IsGroup { get; set; }
        public bool IsParking { get; set; }
        public bool IsReminder { get; set; }
        public List<Attachment.Attachment> Attachments { get; set; } = new List<Attachment.Attachment>();
        public string? Notes { get; set; }
        public List<VisitorPermissionSteps.VisitorPermissionSteps> VisitorPermissionSteps { get; set; } = new List<VisitorPermissionSteps.VisitorPermissionSteps>();
        public List<Visitor.Visitor> Visitors { get; set; } = new List<Visitor.Visitor>();
        public Guid? LK_PermissionTypeId { get; set; }
        public LK_PermissionType? LK_PermissionType { get; set; }
        public int? LK_PermissionSourceId { get; set; }
        public LK_PermissionSource? LK_PermissionSource { get; set; }
        public List<Parking.Parking> Parking { get; set; } = new List<Parking.Parking>();
        public string? ManagerNote { get; set; }

    }
}
