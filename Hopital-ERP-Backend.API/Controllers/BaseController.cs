using Microsoft.AspNetCore.Mvc;

namespace Hospital_ERP_Backend.API.Controllers
{
    [Route("api/Base")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected ActionResult<ApiResponse<T>> CreateResponse<T>(T data, int code = 200, string? message = null)
        {
            return StatusCode(code, new ApiResponse<T>
            {
                statusCode = code,
                Message = message ?? (code == 200 ? "Success" : "Error"),
                Data = data
            });
        }
    }
}
