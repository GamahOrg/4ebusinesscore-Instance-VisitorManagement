namespace _4EPlatform.Domain.Models.Group
{
    public class Group : BaseEntity<Guid>
    {
        public string? GroupName { get; set; }
        public int Groupcode { get; set; }
        public List<Visitor.Visitor> Visitors { get; set; } = new List<Visitor.Visitor>();

    }
}
