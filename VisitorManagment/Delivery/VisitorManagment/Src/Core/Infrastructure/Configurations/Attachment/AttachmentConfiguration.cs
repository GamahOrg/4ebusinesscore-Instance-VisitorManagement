

namespace _4EPlatform.Infrastructure.Configurations
{
    public class AttachmentConfiguration : IEntityTypeConfiguration<Attachment>
    {
        public void Configure(EntityTypeBuilder<Attachment> builder)
        {
            builder.ToTable("Attachments");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.FilePath).IsRequired().HasMaxLength(200);
            builder.Property(a => a.FileName).HasMaxLength(100);

            builder.HasOne(a => a.Permission)
                   .WithMany(p => p.Attachments)
                   .HasForeignKey(a => a.PermissionId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
