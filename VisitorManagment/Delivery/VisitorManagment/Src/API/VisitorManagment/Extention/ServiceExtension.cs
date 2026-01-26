using _4EPlatform.Application.Services.EditedPermission;
using _4EPlatform.Application.Services.GetVisitorsPermissionService;
using _4EPlatform.Application.Services.VisitorPermissionStepsServices;
using _4EPlatform.Application.Services.ViolationServices;
using _4EPlatform.Application.Services.VisitorServices;
using _4EPlatform.Application.Services.GetAllCheckIn_OutVisitor;
namespace _4EPlatform_VisitorManagement.Extention
{
    public static class ServiceExtension
    {
        public static void AddMapGrpcServices(this WebApplication app)
        {

            app.MapGrpcService<GetVisitorPermission>();
            app.MapGrpcService<PermissionVistor>();
            app.MapGrpcService<Visitor>();
            app.MapGrpcService<EditedPermissionService>();
            app.MapGrpcService<VisitorPermissionStepsService>();
            app.MapGrpcService<ViolationService>();
            app.MapGrpcService<GetAllCheckIn_OutVisitorService>();
        }
    }
}
