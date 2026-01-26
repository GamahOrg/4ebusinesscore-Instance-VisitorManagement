namespace _4EPlatform.Domain.Models.LookUpModel
{
    public class LK_PermissionSource : BaseEntity<int>
    {
        public string? NameAR { get; set; }
        public string? NameEN { get; set; }
        public virtual ICollection<_4EPlatform.Domain.Models.Permission.Permission> Permissions { get; set; } = new HashSet<_4EPlatform.Domain.Models.Permission.Permission>();

    }
}
