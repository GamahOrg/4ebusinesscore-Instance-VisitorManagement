

namespace _4EPlatform.Infrastructure.Configurations
{
    public class ViolationConfiguration : IEntityTypeConfiguration<Violation>
    {
        public void Configure(EntityTypeBuilder<Violation> builder)
        {
            builder.ToTable("Violations");

            builder.HasKey(v => v.Id);

            builder.Property(v => v.Violationtype).IsRequired();

            builder.Property(v => v.Date).IsRequired();

            builder.Property(v => v.Location).HasMaxLength(200); 
            
            builder.Property(v => v.Description).IsRequired();

            builder.Property(v => v.VisitorId).IsRequired();

            builder.HasOne(v => v.Visitor)
                              .WithMany(v => v.violations)
                              .HasForeignKey(v => v.VisitorId)
                              .OnDelete(DeleteBehavior.NoAction);


        }
    }
}
