using Azure;
using Hospital_ERP_Backend.Application.Features.RoomTypes.Commands.CreateRoomType;
using Hospital_ERP_Backend.Application.Features.RoomTypes.Commands.DeleteRoomType;
using Hospital_ERP_Backend.Application.Features.RoomTypes.Commands.UpdateRoomType;
using Hospital_ERP_Backend.Application.Features.RoomTypes.Queries.GetAllRoomTypes;
using Hospital_ERP_Backend.Application.Features.RoomTypes.Queries.GetRoomType;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_ERP_Backend.API.Controllers
{
    [Route("api/RoomTypes")]
    [ApiController]
    public class RoomTypesController : BaseController
    {
        private readonly ISender _sender;

        public RoomTypesController(ISender sender)
        {
            _sender = sender;

        }

        [HttpGet(Name = "GetAllRoomTypesAsync")]
        public async Task<ActionResult<ApiResponse<IEnumerable<GetAllRoomTypesResponse>?>>> GetAllAsync([FromQuery] int page = 1)
        {
            GetAllRoomTypesRequest getAllRoomTypes = new GetAllRoomTypesRequest
            {
                Page = page
            };

            var list = await _sender.Send(getAllRoomTypes);
            return CreateResponse<IEnumerable<GetAllRoomTypesResponse>?>(list, StatusCodes.Status200OK, $"Row: {list.Count()}");
        }


        [HttpGet("{ID}", Name = "GetRoomTypeByID")]
        public async Task<ActionResult<ApiResponse<GetRoomTypeResponse?>>> GetByIDAsync([FromRoute] int ID)
        {
            GetRoomTypeRequest getRoomTypeRequest = new GetRoomTypeRequest
            {
                Id = ID
            };
            var response = await _sender.Send(getRoomTypeRequest);
            return CreateResponse<GetRoomTypeResponse?>(response, StatusCodes.Status200OK, "Found Successfully!");
        }

        [HttpPost(Name = "CreateRoomTypeAsync")]
        public async Task<ActionResult<ApiResponse<CreateRoomTypeResponse>>> CreateAsync([FromBody] CreateRoomTypeRequest request)
        {

            var success = await _sender.Send(request);
            return CreatedAtRoute("GetRoomTypeByID", new { ID = success!.Id },
                new ApiResponse<CreateRoomTypeResponse>
                {
                    statusCode = StatusCodes.Status201Created,
                    Message = "Room Type Created Successfully!",
                    Data = success
                });
        }

        [HttpPut(Name = "UpdateRoomTypeAsync")]
        public async Task<ActionResult<ApiResponse<UpdateRoomTypeResponse>>> UpdateAsync([FromBody] UpdateRoomTypeRequest request)
        {
            var response = await _sender.Send(request);
            return CreateResponse<UpdateRoomTypeResponse>(response, StatusCodes.Status200OK, "Room Type Updated Successfully!");
        }

        [HttpDelete("{ID}", Name = "DeleteRoomTypeAsync")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteAsync([FromRoute] int ID)
        {
            DeleteRoomTypeRequest deleteRoomTypeRequest = new DeleteRoomTypeRequest
            {
                Id = ID
            };
            var success = await _sender.Send(deleteRoomTypeRequest);
            return CreateResponse<bool>(success, StatusCodes.Status200OK, "Room Type Deleted Successfully!");
        }

    }
}