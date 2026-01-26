

namespace _4EPlatform.Infrastructure.Configurations
{
    public class VisitorConfiguration : IEntityTypeConfiguration<Visitor>
    {
        public void Configure(EntityTypeBuilder<Visitor> builder)
        {
            var dateOnlyConverter = new DateOnlyConverter();
            var timeOnlyConverter = new TimeOnlyConverter();

            builder.ToTable("Visitors");
            builder.HasKey(v => v.Id);
            builder.Property(v => v.UserId);
            builder.Property(v => v.VisitorName).HasMaxLength(200);
            builder.Property(v => v.NationalID);
            builder.Property(v => v.PhoneNumber);
            builder.Property(v => v.WhatsAppNumber);
            builder.Property(v => v.Email).HasMaxLength(200);
            builder.Property(v => v.permissionStatus).IsRequired();
            builder.Property(v => v.IsFavorite).IsRequired();
            builder.Property(v => v.IsArchived).IsRequired();
            builder.Property(v => v.GroupId).IsRequired(false);
            builder.Property(x=>x.VisitorCode).IsRequired().ValueGeneratedOnAdd();
            builder.Property(p => p.NewStartDate).HasConversion(dateOnlyConverter).HasColumnType("date");
            builder.Property(p => p.NewEndDate).HasConversion(dateOnlyConverter).HasColumnType("date");
            builder.Property(p => p.NewStartTime).HasConversion(timeOnlyConverter).HasColumnType("time");
            builder.Property(p => p.NewEndTime).HasConversion(timeOnlyConverter).HasColumnType("time");


            builder.HasOne(v => v.Group)
                   .WithMany(g => g.Visitors)
                   .HasForeignKey(v => v.GroupId)
                   .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(v => v.Permission)
              .WithMany(p => p.Visitors)
              .HasForeignKey(v => v.PermissionId)
            .OnDelete(DeleteBehavior.NoAction);
            builder.Property(v=>v.Actions).IsRequired(false);
        }
    }
}
