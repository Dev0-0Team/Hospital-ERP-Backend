using Hospital_ERP_Backend.Application.Features.Authentication.Commands.Login;
using Hospital_ERP_Backend.Application.Features.Authentication.Commands.Logout;
using Hospital_ERP_Backend.Application.Features.Authentication.Commands.RefreshTokens;
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

        [HttpPost("Login")]
        public async Task<ActionResult<ApiResponse<LoginResponse>>> LoginAsync(LoginRequest request)
        {
            var response = await _sender.Send(request);

            return CreateResponse<LoginResponse>(
                response,
                StatusCodes.Status200OK,
                "Login Successfully");
        }


        [HttpPost("refresh-token", Name = "RefreshTokenAsync")]
        public async Task<ActionResult<ApiResponse<RefreshTokenResponse>>>
       RefreshTokenAsync([FromBody] RefreshTokenRequest request)
        {
            var response = await _sender.Send(request);

            return CreateResponse(
                response,
                StatusCodes.Status200OK,
                "Token Refreshed Successfully!");
        }

        [HttpPost("logout")]
        public async Task<ActionResult<ApiResponse<bool>>> LogoutAsync([FromBody] LogoutRequest request)
        {
            var result = await _sender.Send(request);

            return CreateResponse(
                result,
                StatusCodes.Status200OK,
                "Logout Successfully");
        }
    }
}