namespace _4EPlatForm.Infrastrucure.Configurations.VisitorPermissionSteps
{
    public class StepsAttachmentCofiguration : IEntityTypeConfiguration<StepsAttachment>
    {
        public void Configure(EntityTypeBuilder<StepsAttachment> builder)
        {
            builder.ToTable("Attachments");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.FilePath).IsRequired().HasMaxLength(200);
            builder.Property(a => a.FileName).HasMaxLength(100);

            builder.HasOne(a => a.VisitorPermissionSteps)
                   .WithMany(p => p.Attachments)
                   .HasForeignKey(a => a.VisitorPermissionStepsId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
