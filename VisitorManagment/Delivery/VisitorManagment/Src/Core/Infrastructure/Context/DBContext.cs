


using _4EPlatform.Domain.Models.CheckIn_OutVisitor;
using _4EPlatform.Domain.Models.Parking;

namespace _4EPlatForm.Infrastructure.Context
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }
        public DbSet<CancelRequest> CancelRequest { get; set; }
        public DbSet<Violation> Violation { get; set; }

        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<VisitorPermissionSteps> VisitorPermissionSteps { get; set; }
        public DbSet<LK_PermissionType> LK_PermissionType { get; set; }
        public DbSet<LK_PermissionSource> LK_PermissionSource { get; set; }
        public DbSet<Parking> Parking { get; set; }
        public DbSet<CheckIn_OutVisitor> CheckIn_OutVisitor { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new VisitorConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionConfiguration());
            modelBuilder.ApplyConfiguration(new AttachmentConfiguration());
            modelBuilder.ApplyConfiguration(new VisitorPermissionStepsConfiguration());
            modelBuilder.ApplyConfiguration(new ViolationConfiguration());
            modelBuilder.ApplyConfiguration(new CancelRequestConfiguration());

        }
        public bool AllMigrationsApplied()
        {
            var applied = this.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            var total = this.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            return !total.Except(applied).Any();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
        public void Migrate()
        {
            this.Database.Migrate();
        }
    }
}