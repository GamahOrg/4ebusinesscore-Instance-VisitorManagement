

namespace _4EPlatform.Infrastructure.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable("Groups");
            builder.HasKey(g => g.Id);
            builder.Property(g => g.GroupName).IsRequired().HasMaxLength(200);
            builder.Property(g => g.Groupcode).IsRequired().ValueGeneratedOnAdd();

        }
    }
}
