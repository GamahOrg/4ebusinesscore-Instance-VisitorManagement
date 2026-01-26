using _4EPlatform.Application.Dto.Command.EditRequestOperation;

namespace _4EPlatform_VisitorManagement.Controllers.EditRequestOperation
{

    
    public class PutEditedrequestController : BaseController
    {
        private readonly IMediator _mediator;

        public PutEditedrequestController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPut]
        [Route("PutStatusEditRequest")]
        public async Task<ResponseDTO> PutStatusEditedRequest(PutEditedRequestOperationCommand request)
        {
            return await _mediator.Send(request);
        }
    }
}
