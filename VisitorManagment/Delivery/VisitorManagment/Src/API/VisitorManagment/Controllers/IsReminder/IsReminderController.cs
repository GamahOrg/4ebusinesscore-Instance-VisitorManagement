using _4EPlatform.Application.Features.IsReminder.Command;

namespace _4EPlatform_VisitorManagement.Controllers.IsReminder
{
    
    public class IsReminderController : BaseController
    {
        private readonly IMediator _mediator;

        public IsReminderController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPut]
        [Route("IsReminder/{PermissionId}")]
        public async Task<ResponseDTO> IsReminder(Guid PermissionId) => await _mediator.Send(new IsReminderCommand { PermissionId = PermissionId });

    }
}
