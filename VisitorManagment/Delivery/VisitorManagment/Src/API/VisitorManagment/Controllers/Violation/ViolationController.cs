using _4EPlatform.Application.Dto.Query.Violation.GetViolationById;
using _4EPlatform.Application.Features.Command.Violation;
using _4EPlatform.Application.Features.Command.Violation.DeleteViolationByID;
using _4EPlatform.Application.Features.Command.Violation.Post;
using _4EPlatform.Application.Features.Command.Violation.Put;

namespace _4EPlatform_VisitorManagement.Controllers.Violation
{
    
    public class ViolationController : BaseController
    {
        private readonly IMediator _mediator;

        public ViolationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [Route("GetViolationById")]
        public async Task<ResponseDTO> GetViolationById([FromQuery] GetViolationByIdQuery request)
        {
            return await _mediator.Send(request);
        }


        #region PostViolationS
        [HttpPost]
        [Route("PostViolation")]
        public async Task<ResponseDTO> PostViolation([FromForm] PostViolationCommand request) => await _mediator.Send(request);

        #endregion


        #region PutViolation
        [HttpPut]
        [Route("PutViolation")]
        public async Task<ResponseDTO> PutViolation([FromForm] PutViolationCommand request) => await _mediator.Send(request);

        #endregion

        #region DeleteViolation
        [HttpDelete]
        [Route("DeleteAllViolationByVisitorId/{VisitorId}")]
        public async Task<ResponseDTO> DeleteAllViolationByVisitorId(Guid VisitorId) => await _mediator.Send(new DeleteViolationCommand(VisitorId));

        #endregion

        [HttpDelete]
        [Route("DeleteViolationById/{ViolationId}")]
        public async Task<ResponseDTO> DeleteViolationById(Guid ViolationId) => await _mediator.Send(new DeleteViolationByIDCommand { VIolationId = ViolationId });

    }
}
