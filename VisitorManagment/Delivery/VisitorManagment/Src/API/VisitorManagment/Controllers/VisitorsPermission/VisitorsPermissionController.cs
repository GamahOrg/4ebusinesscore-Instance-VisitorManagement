using _4EPlatform.Application.Dto.Command.PermissionOperation;
using _4EPlatform.Application.Features.Command.AddGroupToArchive;
using _4EPlatform.Application.Features.Command.AddGroupToFouvrite;
using _4EPlatform.Application.Features.Command.RenewPermission;

namespace _4EPlatform_VisitorManagement.Controllers.VisitorsPermission
{
    
    public class VisitorsPermissionController : BaseController
    {
        private readonly IMediator _mediator;

        public VisitorsPermissionController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPut("PutVisitorsReportStatus")]
        
        public async Task<ResponseDTO> PutVisitorsReportStatus([FromQuery] PutPermissionStatusCommand dto)
        {
            
            return await _mediator.Send(dto);
        }
        [HttpPut("PutGroupReportStatus")]

        public async Task<ResponseDTO> PutGroupReportStatus([FromQuery] PutGroupStatusCommand dto)
        {

            return await _mediator.Send(dto);
        }
        [HttpPut("RenewPermission")]
        public async Task<ResponseDTO>RenewPermissionRequest(RenewPermissionCommand request)=>await _mediator.Send(request);

        [HttpPut("AddGroupToFouvrite/{GroupId}")]
        public async Task<ResponseDTO> AddGroupToFouvrite( Guid GroupId , bool isFouvrite) => await _mediator.Send(new AddGroupToFouvriteCommand() { GroupId=GroupId , IsFouvrite = isFouvrite});

        [HttpPut("AddGroupToArchive/{GroupId}")]
        public async Task<ResponseDTO> AddGroupToArchive(Guid GroupId, bool isArchive) => await _mediator.Send(new AddGroupToArchiveCommand() { GroupId = GroupId, IsArchive = isArchive });

    }
}
