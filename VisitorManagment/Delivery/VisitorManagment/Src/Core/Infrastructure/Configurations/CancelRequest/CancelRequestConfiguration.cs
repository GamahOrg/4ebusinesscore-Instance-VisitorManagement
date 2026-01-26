

namespace _4EPlatform.Infrastrucure.Configurations
{
    public class CancelRequestConfiguration : IEntityTypeConfiguration<CancelRequest>
    {
        public void Configure(EntityTypeBuilder<CancelRequest> builder)
        {


            builder.ToTable("CancelRequests");
            builder.HasKey(v => v.Id);
            builder.Property(v => v.ReasonForCancled).IsRequired();
            builder.Property(v => v.status).IsRequired();
            builder.Property(v => v.reason).IsRequired(false);
            builder.Property(v => v.ViolationId).IsRequired(false);
            builder.Property(v => v.VisitorId).IsRequired();




            //builder.HasOne(cr => cr.Violation)
            //      .WithOne(v => v.CancelRequest)
            //      .HasForeignKey<CancelRequest>(cr => cr.ViolationId)
            //.OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(cr => cr.Violation)
               .WithMany(v => v.CancelRequest)  
               .HasForeignKey(cr => cr.ViolationId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(cr => cr.Visitor)
                   .WithMany(cr=>cr.CancelRequestss) 
                   .HasForeignKey(cr => cr.VisitorId)
            .OnDelete(DeleteBehavior.NoAction);


        }
    }
}
