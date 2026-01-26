

namespace _4EPlatform.Infrastructure.Configurations
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {

            var dateOnlyConverter = new DateOnlyConverter();
            var timeOnlyConverter = new TimeOnlyConverter();

            builder.ToTable("Permissions");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.PermissionReason).IsRequired(false);
            builder.Property(p => p.PermissionCode).IsRequired().ValueGeneratedOnAdd(); 
            //builder.Property(p => p.PermissionType).IsRequired();
            builder.Property(p => p.OrgId).IsRequired();
            builder.Property(p => p.RecivedId);

            builder.Property(p => p.StartDate).IsRequired().HasConversion(dateOnlyConverter).HasColumnType("date");
            builder.Property(p => p.EndDate).IsRequired().HasConversion(dateOnlyConverter).HasColumnType("date");
            builder.Property(p => p.StartTime).IsRequired().HasConversion(timeOnlyConverter).HasColumnType("time");
            builder.Property(p => p.EndTime).IsRequired().HasConversion(timeOnlyConverter).HasColumnType("time");
            builder.Property(p => p.Notes).HasMaxLength(1000);
            builder.Property(p => p.IsGroup).IsRequired();
            builder.HasOne(x=>x.LK_PermissionType).WithMany(x=>x.Permissions)
                .HasForeignKey(x=>x.LK_PermissionTypeId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.LK_PermissionSource).WithMany(x => x.Permissions)
                .HasForeignKey(x => x.LK_PermissionSourceId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);



        }
    }
}
