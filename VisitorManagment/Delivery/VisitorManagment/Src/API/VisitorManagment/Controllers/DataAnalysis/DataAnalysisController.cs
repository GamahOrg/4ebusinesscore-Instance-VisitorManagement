using _4EPlatform.Application.Features.DataAnalysis.AttachmentIndicators.Query;
using _4EPlatform.Application.Features.DataAnalysis.AvaragePermissionDuration.Query;
using _4EPlatform.Application.Features.DataAnalysis.CountOfLoginsAndLogouts.Guery;
using _4EPlatform.Application.Features.DataAnalysis.CountPermission.Query;
using _4EPlatform.Application.Features.DataAnalysis.DailyNumberOfVisitors.Query;
using _4EPlatform.Application.Features.DataAnalysis.DistributeVisitorsAccordingToGroups.Query;
using _4EPlatform.Application.Features.DataAnalysis.OperationalEfficiency.Query;
using _4EPlatform.Application.Features.DataAnalysis.Parking.Query;
using _4EPlatform.Application.Features.DataAnalysis.UsageAnalysis.Query;
namespace _4EPlatform_VisitorManagement.Controllers.DataAnalysis
{
    
    public class DataAnalysisController : BaseController
    {
        private readonly IMediator _mediator;

        public DataAnalysisController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetCountPermission")]
        public async Task<ResponseDTO> GetCountPermission()
        {
            return await _mediator.Send(new GetCountPermissionCommand());
        }
        [HttpGet("CountOfLoginsAndLogouts")]
        public async Task<ResponseDTO> CountOfLoginsAndLogouts(DateTime date)
        {
            return await _mediator.Send(new CountOfLoginsAndLogoutsCommand { date = date});
        }
        [HttpGet("GetCountCarsInPark")]
        public async Task<ResponseDTO> GetCountCarsInPark()
        {
            return await _mediator.Send(new GetCarsInParkCommand ());
        }
        [HttpGet("AverageDurationPerPermissionType")]
        public async Task<ResponseDTO> AverageDurationPerPermissionType()
        {
            return await _mediator.Send(new GetAvaragePermissionDurationCommand());
        }
        [HttpGet("DailyNumberOfVisitors")]
        public async Task<ResponseDTO> DailyNumberOfVisitors(DateTime date)
        {
            return await _mediator.Send(new DailyNumberOfVisitorsCommand { Date = date });
        }
        [HttpGet("DistributeVisitorsAccordingToGroups")]
        public async Task<ResponseDTO> DistributeVisitorsAccordingToGroups()
        {
            return await _mediator.Send(new DistributeVisitorsAccordingToGroupsQuery());
        }
        [HttpGet("AttachmentIndicators")]
        public async Task<ResponseDTO> AttachmentIndicators()
        {
            return await _mediator.Send(new AttachmentIndicatorsQuery());
        }
        [HttpGet("UsageAnalysis")]
        public async Task<ResponseDTO> UsageAnalysis()
        {
            return await _mediator.Send(new UsageAnalysisQuery());
        }
        [HttpGet("OperationalEfficiency")]
        public async Task<ResponseDTO> OperationalEfficiency()
        {
            return await _mediator.Send(new OperationalEfficiencyQuery());
        }
    }
}
