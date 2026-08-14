using Hospital_ERP_Backend.Application.Features.EmergencyCases.Commands.CreateEmergencyCases;
using Hospital_ERP_Backend.Application.Features.EmergencyCases.Commands.DeleteEmergencyCases;
using Hospital_ERP_Backend.Application.Features.EmergencyCases.Commands.UpdateEmergencyCases;
using Hospital_ERP_Backend.Application.Features.EmergencyCases.Queries.GetAllEmergencyCases;
using Hospital_ERP_Backend.Application.Features.EmergencyCases.Queries.GetEmergencyCase;
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

        [HttpGet(Name = "GetAllEmergencyCasesAsync")]
        public async Task<ActionResult<ApiResponse<IEnumerable<GetAllEmergencyCasesResponse>?>>> GetAllAsync([FromQuery] int page = 1)
        {
            var request = new GetAllEmergencyCasesRequest
            {
                Page = page
            };

            var list = await _sender.Send(request);

            return CreateResponse<IEnumerable<GetAllEmergencyCasesResponse>?>(
                list,
                StatusCodes.Status200OK,
                $"Rows: {list.Count()}");
        }

        [HttpGet("{ID:int}", Name = "GetEmergencyCaseByIdAsync")]
        public async Task<ActionResult<ApiResponse<GetEmergencyCaseResponse?>>> GetByIdAsync([FromRoute] int ID)
        {
            var request = new GetEmergencyCaseRequest
            {
                Id = ID
            };

            var response = await _sender.Send(request);

            return CreateResponse<GetEmergencyCaseResponse?>(
                response,
                StatusCodes.Status200OK,
                "Emergency Case found successfully!");
        }

        [HttpPost(Name = "CreateEmergencyCasesAsync")]
        public async Task<ActionResult<ApiResponse<CreateEmergencyCasesResponse>>> CreateAsync([FromBody] CreateEmergencyCasesRequest request)
        {
            var response = await _sender.Send(request);

            //return CreatedAtRoute(
            //    "GetEmergencyCaseByIdAsync",
            //    new { ID = response.Id },
            //    response);


            return CreateResponse<CreateEmergencyCasesResponse>(
                response,
                StatusCodes.Status200OK,
                "Emergency Case created successfully!"
                );
        }

        [HttpPut(Name = "UpdateEmergencyCasesAsync")]
        public async Task<ActionResult<ApiResponse<UpdateEmergencyCasesResponse>>> UpdateAsync([FromBody] UpdateEmergencyCasesRequest request)
        {
            var response = await _sender.Send(request);

            return CreateResponse<UpdateEmergencyCasesResponse>(
                response,
                StatusCodes.Status200OK,
                "Emergency Case updated successfully!");
        }

        [HttpDelete("{ID:int}", Name = "DeleteEmergencyCasesAsync")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteAsync([FromRoute] int ID)
        {
            var request = new DeleteEmergencyCasesRequest
            {
                Id = ID
            };

            var result = await _sender.Send(request);

            return CreateResponse<bool>(
                result,
                StatusCodes.Status200OK,
                "Emergency Case deleted successfully!");
        }
    }
}

