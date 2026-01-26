using _4EPlatform.Application.Features.LookUpsFeatures.Lk_PermissionType.Command.Delete;
using _4EPlatform.Application.Features.LookUpsFeatures.Lk_PermissionType.Command.Post;
using _4EPlatform.Application.Features.LookUpsFeatures.Lk_PermissionType.Command.Put;
using _4EPlatform.Application.Features.LookUpsFeatures.Lk_PermissionType.Query.GetAll;
using _4EPlatform.Application.Features.LookUpsFeatures.Lk_PermissionType.Query.GetById;


namespace _4EPlatform_VisitorManagement.Controllers.LookUps
{
    
    public class LookUpsController : BaseController
    {
        private readonly IMediator _mediator;

        public LookUpsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("PostLkPermissiontype")]
        public async Task<ResponseDTO> PostLkAgreement([FromQuery] PostLkPermissionTypeCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpDelete("DeleteLkPermissiontype/{id}")]
        public async Task<ResponseDTO> DeleteLkAgreement(Guid id)
        {
            return await _mediator.Send(new DeleteLkPermissionTypeCommand { Id = id });
        }

        [HttpGet("GetAllLKPermissiontypes")]
        public async Task<ResponseDTO> GetAllLkAgreements()
        {
            return await _mediator.Send(new GetAllLkPermissionTypeCommand { });
        }
        [HttpGet("GetLKPermissionById/{id}")]
        public async Task<ResponseDTO> GetLKPermissionById(Guid id)
        {
            return await _mediator.Send(new GetLkPermissionTypeByIdCommand { Id = id });
        }
        [HttpPut("PutLkPermissiontype")]
        public async Task<ResponseDTO> PutLkPermissiontype([FromQuery] PutLkPermissionTypeCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
