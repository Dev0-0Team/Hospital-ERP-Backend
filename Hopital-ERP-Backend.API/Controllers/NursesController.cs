using Hospital_ERP_Backend.Application.Features.Nurses.Commands.CreateNurse;
using Hospital_ERP_Backend.Application.Features.Nurses.Commands.DeleteNurse;
using Hospital_ERP_Backend.Application.Features.Nurses.Commands.UpdateNurse;
using Hospital_ERP_Backend.Application.Features.Nurses.Queries.GetAllNurses;
using Hospital_ERP_Backend.Application.Features.Nurses.Queries.GetNurse;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_ERP_Backend.API.Controllers
{
    [Route("api/Nurses")]
    [ApiController]
    public class NursesController : BaseController
    {
        private readonly ISender _sender;

        public NursesController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet(Name = "GetAllNursesAsync")]
        public async Task<ActionResult<ApiResponse<IEnumerable<GetAllNursesResponse>?>>> GetAllAsync([FromQuery] int page = 1)
        {
            GetAllNursesRequest request = new()
            {
                Page = page
            };

            var list = await _sender.Send(request);

            return CreateResponse<IEnumerable<GetAllNursesResponse>?>(
                list,
                StatusCodes.Status200OK,
                $"Rows: {list.Count()}");
        }

        [HttpGet("{ID:int}", Name = "GetNurseByIdAsync")]
        public async Task<ActionResult<ApiResponse<GetNurseResponse?>>> GetByIdAsync([FromRoute] int ID)
        {
            GetNurseRequest request = new()
            {
                Id = ID
            };

            var department = await _sender.Send(request);

            return CreateResponse<GetNurseResponse?>(
                department,
                StatusCodes.Status200OK,
                "Nurse found successfully!");
        }

        [HttpPost(Name = "CreateNurseAsync")]
        public async Task<ActionResult<ApiResponse<CreateNurseResponse>>> CreateAsync([FromBody] CreateNurseRequest request)
        {
            var response = await _sender.Send(request);

            return CreatedAtRoute(
                "GetNurseByIdAsync",
                new
                {
                    ID = response.Id
                },
                new ApiResponse<CreateNurseResponse>
                {
                    statusCode = 201,
                    Message = "Nurse Created Successfully!",
                    Data = response
                });
        }

        [HttpPut(Name = "UpdateNurseAsync")]
        public async Task<ActionResult<ApiResponse<UpdateNurseResponse>>> UpdateAsync([FromBody] UpdateNurseRequest request)
        {
            var response = await _sender.Send(request);

            return CreateResponse(
                response,
                StatusCodes.Status200OK,
                "Nurse updated successfully!");
        }

        [HttpDelete("{ID:int}", Name = "DeleteNurseAsync")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteAsync([FromRoute] int ID)
        {
            DeleteNurseRequest request = new()
            {
                Id = ID
            };

            var success = await _sender.Send(request);

            return CreateResponse(
                success,
                StatusCodes.Status200OK,
                "Nurse deleted successfully!");
        }
    }
}
