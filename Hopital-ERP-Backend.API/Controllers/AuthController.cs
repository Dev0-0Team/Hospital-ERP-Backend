using Hospital_ERP_Backend.Application.Features.Authentication.Commands.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_ERP_Backend.API.Controllers
{
    [Route("api/Auth")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly ISender _sender;

        public AuthController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("Register", Name = "RegisterAsync")]
        public async Task<ActionResult<ApiResponse<RegisterResponse>>> RegisterAsync([FromBody] RegisterRequest request)
        {
            var response = await _sender.Send(request);

            return CreateResponse<RegisterResponse>(
                response,
                StatusCodes.Status201Created,
                "User Registered Successfully!");
        }
    }
}