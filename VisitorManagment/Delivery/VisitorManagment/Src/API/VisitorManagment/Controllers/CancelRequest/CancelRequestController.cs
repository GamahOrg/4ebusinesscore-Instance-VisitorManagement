using _4EPlatform.Application.Dto.Command.CancelRequest;
using _4EPlatform.Application.Dto.Command.CancelRequestOperation;

namespace _4EPlatform_VisitorManagement.Controllers.CancelRequest
{
    
    public class CancelRequestController : BaseController
    {
        private readonly IMediator _mediator;

        public CancelRequestController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [Route("PostCancelRequest")]
        public async Task<ResponseDTO> PostCancelRequest([FromForm] PostCancelRequestCommand request)
        {
            return await _mediator.Send(request);
        }
        [HttpPut]
        [Route("PutStatusCancelRequest")]
        public async Task<ResponseDTO> PutStatusCancelRequest([FromForm] PutCancelRequestOperationCommand request)
        {
            return await _mediator.Send(request);
        }
        [HttpPut]
        [Route("PutStatusCancelRequestGroup")]
        public async Task<ResponseDTO> PutStatusCancelRequestGroup([FromForm] PutCancelRequestOperationGroupCommand request)
        {
            return await _mediator.Send(request);
        }
        [HttpPost]
        [Route("PostCancelRequestGroup")]
        public async Task<ResponseDTO> PostCancelRequestGroup([FromForm] PostCancelRequestGroupCommand request)
        {
            return await _mediator.Send(request);
        }
    }
}
