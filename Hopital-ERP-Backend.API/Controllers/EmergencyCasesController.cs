using Hospital_ERP_Backend.Application.Features.EmergencyCases.Commands.CreateEmergencyCases;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_ERP_Backend.API.Controllers
{
    [Route("api/EmergencyCases")]
    [ApiController]
    public class EmergencyCasesController : BaseController
    {
        private readonly ISender _sender;

        public EmergencyCasesController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost(Name = "CreateEmergencyCasesAsync")]
        public async Task<ActionResult<ApiResponse<CreateEmergencyCasesResponse>>> CreateAsync([FromBody] CreateEmergencyCasesRequest request)
        {
            var response = await _sender.Send(request);

            return CreateResponse(
                response,
                StatusCodes.Status201Created,
                "Emergency case created successfully!");
        }
    }
}
