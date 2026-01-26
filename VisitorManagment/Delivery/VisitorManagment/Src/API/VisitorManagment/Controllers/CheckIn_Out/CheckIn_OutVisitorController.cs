


namespace _4EPlatform_VisitorManagement.Controllers.CheckIn_Out
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CheckIn_OutVisitorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CheckIn_OutVisitorController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("CheckInVisitor")]
        public async Task<ResponseDTO> CheckInVisitor(Guid visitorid , [PreventInjection] string? Comment , bool ISTransit) => await _mediator.Send(new CheckInVisitorCommand { VisitorId = visitorid , Comment = Comment, ISTransit = ISTransit});
        [HttpPost("CheckOutVisitor/{visitorid}")]
        public async Task<ResponseDTO> CheckOutVisitor(Guid visitorid) => await _mediator.Send(new CheckOutVisitorCommand { VisitorId = visitorid });
        [HttpGet("GetCheckOutVisitor/{visitorid}")]
        public async Task<ResponseDTO> GetCheckOutVisitor(Guid visitorid) => await _mediator.Send(new GetCheckIn_OutVisitorCommand { VisitorId = visitorid });
    }
}
