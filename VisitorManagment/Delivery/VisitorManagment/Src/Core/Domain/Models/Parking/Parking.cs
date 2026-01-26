

namespace _4EPlatform.Domain.Models.Parking
{
    public class Parking :BaseEntity<Guid>
    {
        public string? CarType { get; set; }

        public string? CarPlateData { get; set; }
        public string? CarColor { get; set; }
        public string? CarModel { get; set; }
        public string? Duration { get; set; }
        public Guid PermissionId { get; set; }
        public _4EPlatform.Domain.Models.Permission.Permission Permission { get; set; }
    }
}
