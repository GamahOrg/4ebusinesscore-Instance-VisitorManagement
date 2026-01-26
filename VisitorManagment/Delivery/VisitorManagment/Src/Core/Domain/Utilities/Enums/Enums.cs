namespace Domain.Enums
{
    public enum State
    {
        NotDeleted,
        Deleted
    }
    public enum StatusEnum
    {
        FailedToSave,
        SavedSuccessfully,
        Exception,
        Success,
        Failed,
        FailedToFindTheObject,
        AlreadyExisting
    }
    public enum UserGender
    {
        Male,
        Female
    }
    public enum MaritalStatus
    {
        Single,
        married
    }
    public enum Color
    {
        Red,
        Green,
        Yellow,
    }
    public enum PermissionType
    {
        WorkingPermission = 0,
        PersonalPermission = 1,
    }
    public enum PermissionSource
    {
        Internal,
        External
    }

    public enum PermissionStatus
    {
        Pending,
        InProgress,
        Approved,
        Canceled,
        Finshed,
        Reject

    }

    public enum CanceledReason
    {
        Violation,
        Other
    }
    public enum AttachmentPosition
    {
        InPermission = 0,
        InActionStatus = 1
    }

    public enum CancelRequestStatus
    {
        pennding,
        Approved,
        Rejected
    }
    public enum ActionType
    {
        AddNewVisitor,
        CanceledPermissionForVisitor,
        EditPermissionInfo,
        updatedPermissionInfo,
        RecordedViolation,
        AcceptedPermission,
        CancelGroup,
        ReNewPermissionForVisitor,
        rejectUpdated,
        RejectRenew,
        RejectPermission,
        RejectCancel
        
    }
    public enum Actions
    {
        AddNewVisitor,
        ReNewPermissionForVisitor,
    }
    public enum PrmissionStatusRequest
    {

        Pending = 0,
        AddNewVisitor = 1,
        ReNewPermissionForVisitor = 2,
    }
    public enum IsFavorite
    {
        True,
        False,
        NotAnyOne
    }
    public enum PutPermissionStatus
    {

        Approved = 2,
        Reject = 5
    }
    public enum PutRequestStatus
    {

        Approved = 1,
        Reject = 2
    }
    public enum PutStatus
    {
        pennding,
        Approved,
        Rejected
    }
    public enum TransitStatus
    {
        Entry,
        Exit,
        none,

    }
}