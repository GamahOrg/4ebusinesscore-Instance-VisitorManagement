

namespace _4EPlatform.Domain.Models.LookUpModel
{
    public class LK_PermissionType:BaseEntity<Guid>
    {
        public string? NameAr { get; set; }
        public string? NameEn { get; set; }
        public virtual ICollection<_4EPlatform.Domain.Models.Permission.Permission> Permissions { get; set; } = new HashSet<_4EPlatform.Domain.Models.Permission.Permission>();

    }
}
