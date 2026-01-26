using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _4EPlatform_VisitorManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BaseController : ControllerBase
    {
    }
}
