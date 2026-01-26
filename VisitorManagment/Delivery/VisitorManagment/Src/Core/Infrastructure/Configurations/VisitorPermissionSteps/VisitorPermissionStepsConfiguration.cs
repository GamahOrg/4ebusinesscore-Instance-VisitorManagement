

namespace _4EPlatform.Infrastructure.Configurations
{
    public class VisitorPermissionStepsConfiguration : IEntityTypeConfiguration<VisitorPermissionSteps>
    {
        public void Configure(EntityTypeBuilder<VisitorPermissionSteps> builder)
        {
            var dateOnlyConverter = new DateOnlyConverter();
            var timeOnlyConverter = new TimeOnlyConverter();

            builder.ToTable("VisitorPermissionSteps");

            builder.HasKey(vps => vps.Id);
            builder.Property(vps => vps.Description).HasMaxLength(200);
            builder.Property(vps => vps.Reason);
            builder.Property(vps => vps.Date);
            builder.Property(p => p.StartDate).HasConversion(dateOnlyConverter).HasColumnType("date");
            builder.Property(p => p.EndDate).HasConversion(dateOnlyConverter).HasColumnType("date");
            builder.Property(p => p.StartTime).HasConversion(timeOnlyConverter).HasColumnType("time");
            builder.Property(p => p.EndTime).HasConversion(timeOnlyConverter).HasColumnType("time");
            builder.Property(vps => vps.permissionStatus);
            builder.Property(vps => vps.UserId);
            builder.Property(vps => vps.VisitorName);
            builder.Property(vps => vps.NationalID);
            builder.Property(vps => vps.PhoneNumber);
            builder.Property(vps => vps.WhatsAppNumber);
            builder.Property(vps => vps.Email);
            builder.Property(vps => vps.OrgId);
            builder.Property(vps => vps.RecivedId);
            builder.Property(vps => vps.Notes);
            builder.Property(vps => vps.PutStatus);





            builder.HasOne(vps => vps.Permission)
                   .WithMany(p => p.VisitorPermissionSteps)
                   .HasForeignKey(vps => vps.PermissionId)
            .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(vps => vps.cancelRequest)             // Ensure cancelRequest is a navigation property in VisitorPermissionSteps
                   .WithMany(p => p.VisitorPermissionSteps)
                   .HasForeignKey(x => x.CancelRequestId).IsRequired(false);// Ensure VisitorPermissionSteps is a navigation property in CancelRequest
                     // Correctly specify the foreign key property


            builder.HasOne(vps => vps.Visitor)
                .WithMany(p => p.VisitorPermissionSteps)
                .HasForeignKey(vps => vps.VisitorId)
                .OnDelete(DeleteBehavior.NoAction);


        }
    }
}
