using _4EPlatform.Application.Features.LookUpsFeatures.LK_PermissionSourceFeatures.Command.Delete;
using _4EPlatform.Application.Features.LookUpsFeatures.LK_PermissionSourceFeatures.Command.POST;
using _4EPlatform.Application.Features.LookUpsFeatures.LK_PermissionSourceFeatures.Command.PUT;
using _4EPlatform.Application.Features.LookUpsFeatures.LK_PermissionSourceFeatures.Query.GetAll;
using _4EPlatform.Application.Features.LookUpsFeatures.LK_PermissionSourceFeatures.Query.GetById;

namespace _4EPlatform_VisitorManagement.Controllers.LookUps
{
    
    public class PermissionSourceLookUpController : BaseController
    {
        private readonly IMediator _mediator;

        public PermissionSourceLookUpController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #region Post
        [HttpPost("PostLkPermissionSource")]
        public async Task<ResponseDTO> PostLkPermissionSource([FromForm] PostPermessionSourceDto command) => await _mediator.Send(new PostPermessionSourceCommand { PostPermessionSourceDto = command });

        #endregion

        #region GetAll
        [HttpGet("GetAllLK_PermissionSource")]

        public async Task<ResponseDTO> GetAllLK_PermissionSource(string? searchWord, int pageNumber, int pageSize)
        {
            return await _mediator.Send(new GetAllLK_PermissionSourceQuery { PageNumber = pageNumber, PageSize = pageSize, SearchWord = searchWord });
        }
        #endregion

        #region GetById
        [HttpGet("GetLK_PermissionSourceById/{id}")]

        public async Task<ResponseDTO> GetByIdLK_PermissionSource(int id)
        {
            return await _mediator.Send(new GetByIdLK_PermissionSourceQuery { Id = id });
        }
        #endregion

        #region Put

        [HttpPut("PutLKPermissionSource/{Id}")]
        public async Task<ResponseDTO> PutLK_PermissionSource(int Id, [FromForm] PutLKPermissionSourceDTO PutLookupDTO)
        {
            return await _mediator.Send(new PutLK_PermissionSourceCommand { Id = Id, PutLKPermissionSourceDTO = PutLookupDTO });
        }
        #endregion

        #region Delete
        [HttpDelete("DeleteLK_PermissionSource/{Id}")]
        public async Task<ResponseDTO> DeleteLkPermissionSource(int Id)
        {
            return await _mediator.Send(new DeleteLKPermissionSourceCommand { Id = Id });
        }
        #endregion



    }
}
