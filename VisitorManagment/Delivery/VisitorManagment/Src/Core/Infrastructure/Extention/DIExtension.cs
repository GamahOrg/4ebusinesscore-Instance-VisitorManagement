

namespace _4EPlatForm.Infrastrucure.Extention
{
    public static class DIExtension
    {
        public static void AddUnitOfWorkRepositry(this IServiceCollection services)
        {
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped(typeof(IGRepository<>), typeof(GRepository<>));
            services.AddScoped<IGroupRepository, GroupRepository>();         
            services.AddScoped<ICancelRequestReposatiry, CancelRequestReposatiry>();
            services.AddScoped<IViolationReposatiry, ViolationReopsatiry>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IVisitorRepository, VisitorRepository>();
            services.AddScoped<IVisitorPermissionStepsRepository, VisitorPermissionStepsRepository>();
            services.AddScoped(typeof(IGRepositoryLookUp<>), typeof(GRepositoryLookUp<>));
        }

        public static void AddDbConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

                options.EnableSensitiveDataLogging(true);
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
        }
    }
}
