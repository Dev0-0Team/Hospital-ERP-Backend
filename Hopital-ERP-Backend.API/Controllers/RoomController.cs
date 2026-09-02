using Azure;
using Hospital_ERP_Backend.Application.Features.Rooms.Commands.CreateRoom;
using Hospital_ERP_Backend.Application.Features.Rooms.Commands.DeleteRoom;
using Hospital_ERP_Backend.Application.Features.Rooms.Commands.UpdateRoom;
using Hospital_ERP_Backend.Application.Features.Rooms.Queries.GetAllRooms;
using Hospital_ERP_Backend.Application.Features.Rooms.Queries.GetRoom;
using MediatR;
using Hospital_ERP_Backend.Application.Security.Authorization;
using Hospital_ERP_Backend.Domain.Enums.PermissionBits;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_ERP_Backend.API.Controllers
{
    [Route("api/Rooms")]
    [ApiController]
    [Authorize]
    public class RoomsController : BaseController
    {
        private readonly ISender _sender;

        public RoomsController(ISender sender)
        {
            _sender = sender;

        }

        [HasPermission<HospitalFacilityPermissions>(HospitalFacilityPermissions.RoomsRead)]
        [HttpGet(Name = "GetAllRoomsAsync")]
        public async Task<ActionResult<ApiResponse<IEnumerable<GetAllRoomsResponse>?>>> GetAllAsync([FromQuery] int page = 1)
        {
            GetAllRoomsRequest getAllRoomsRequest = new GetAllRoomsRequest
            {
                Page = page
            };

            var list = await _sender.Send(getAllRoomsRequest);
            return CreateResponse<IEnumerable<GetAllRoomsResponse>?>(list, StatusCodes.Status200OK, $"Row: {list.Count()}");
        }


        [HasPermission<HospitalFacilityPermissions>(HospitalFacilityPermissions.RoomsRead)]
        [HttpGet("{ID}", Name = "GetRoomByID")]
        public async Task<ActionResult<ApiResponse<GetRoomResponse?>>> GetByIDAsync([FromRoute] int ID)
        {
            GetRoomRequest getRoomRequest = new GetRoomRequest
            {
                Id = ID
            };
            var response = await _sender.Send(getRoomRequest);
            return CreateResponse<GetRoomResponse?>(response, StatusCodes.Status200OK, "Found Successfully!");
        }

        [HasPermission<HospitalFacilityPermissions>(HospitalFacilityPermissions.RoomsCreate)]
        [HttpPost(Name = "CreateRoomAsync")]
        public async Task<ActionResult<ApiResponse<CreateRoomResponse>>> CreateAsync([FromBody] CreateRoomRequest request)
        {

            var success = await _sender.Send(request);
            return CreatedAtRoute("GetRoomByID", new { ID = success!.Id },
                new ApiResponse<CreateRoomResponse>
                {
                    statusCode = StatusCodes.Status201Created,
                    message = "Room Created Successfully!",
                    data = success
                });
        }

        [HasPermission<HospitalFacilityPermissions>(HospitalFacilityPermissions.RoomsUpdate)]
        [HttpPut(Name = "UpdateRoomAsync")]
        public async Task<ActionResult<ApiResponse<UpdateRoomResponse>>> UpdateAsync([FromBody] UpdateRoomRequest request)
        {
            var response = await _sender.Send(request);
            return CreateResponse<UpdateRoomResponse>(response, StatusCodes.Status200OK, "Room Updated Successfully!");
        }

        [HasPermission<HospitalFacilityPermissions>(HospitalFacilityPermissions.RoomsDelete)]
        [HttpDelete("{ID}", Name = "DeleteRoomAsync")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteAsync([FromRoute] int ID)
        {
            DeleteRoomRequest deleteRoomRequest = new DeleteRoomRequest
            {
                Id = ID
            };
            var success = await _sender.Send(deleteRoomRequest);
            return CreateResponse<bool>(success, StatusCodes.Status200OK, "Room Deleted Successfully!");
        }

    }
}