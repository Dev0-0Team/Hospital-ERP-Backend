using Hospital_ERP_Backend.Application.Features.RoomAssignments.Commands.CreateRoomAssignment;
using Hospital_ERP_Backend.Application.Features.RoomAssignments.Commands.DeleteRoomAssignment;
using Hospital_ERP_Backend.Application.Features.RoomAssignments.Commands.UpdateRoomAssignment;
using Hospital_ERP_Backend.Application.Features.RoomAssignments.Queries.GetAllRoomAssignments;
using Hospital_ERP_Backend.Application.Features.RoomAssignments.Queries.GetRoomAssignment;
using Hospital_ERP_Backend.Application.Security.Authorization;
using Hospital_ERP_Backend.Domain.Enums.PermissionBits;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_ERP_Backend.API.Controllers
{
    [Route("api/RoomAssignments")]
    [ApiController]
    [Authorize]

    public class RoomAssignmentsController : BaseController
    {
        private readonly ISender _sender;

        public RoomAssignmentsController(ISender sender)
        {
            _sender = sender;
        }

        [HasPermission<HospitalFacilityPermissions>(HospitalFacilityPermissions.RoomAssignmentsRead)]
        [HttpGet(Name = "GetAllRoomAssignmentsAsync")]
        public async Task<ActionResult<ApiResponse<IEnumerable<GetAllRoomAssignmentsResponse>?>>> GetAllAsync([FromQuery] int page = 1)
        {
            GetAllRoomAssignmentsRequest getAllRoomAssignmentsRequest = new GetAllRoomAssignmentsRequest
            {
                Page = page
            };

            var list = await _sender.Send(getAllRoomAssignmentsRequest);
            return CreateResponse<IEnumerable<GetAllRoomAssignmentsResponse>?>(list, StatusCodes.Status200OK, $"Row: {list.Count()}");
        }

        [HasPermission<HospitalFacilityPermissions>(HospitalFacilityPermissions.RoomAssignmentsRead)]
        [HttpGet("{ID}", Name = "GetRoomAssignmentByID")]
        public async Task<ActionResult<ApiResponse<GetRoomAssignmentResponse?>>> GetByIDAsync([FromRoute] int ID)
        {
            GetRoomAssignmentRequest getRoomAssignmentRequest = new GetRoomAssignmentRequest
            {
                Id = ID
            };
            var response = await _sender.Send(getRoomAssignmentRequest);
            return CreateResponse<GetRoomAssignmentResponse?>(response, StatusCodes.Status200OK, "Found Successfully!");
        }

        [HasPermission<HospitalFacilityPermissions>(HospitalFacilityPermissions.RoomAssignmentsCreate)]
        [HttpPost(Name = "CreateRoomAssignmentAsync")]
        public async Task<ActionResult<ApiResponse<CreateRoomAssignmentResponse>>> CreateAsync([FromBody] CreateRoomAssignmentRequest request)
        {
            var success = await _sender.Send(request);
            return CreatedAtRoute("GetRoomAssignmentByID", new { ID = success!.Id },
                new ApiResponse<CreateRoomAssignmentResponse>
                {
                    statusCode = StatusCodes.Status201Created,
                    message = "Room Assignment Created Successfully!",
                    data = success
                });
        }

        [HasPermission<HospitalFacilityPermissions>(HospitalFacilityPermissions.RoomAssignmentsUpdate)]
        [HttpPut(Name = "UpdateRoomAssignmentAsync")]
        public async Task<ActionResult<ApiResponse<UpdateRoomAssignmentResponse>>> UpdateAsync([FromBody] UpdateRoomAssignmentRequest request)
        {
            var response = await _sender.Send(request);
            return CreateResponse<UpdateRoomAssignmentResponse>(response, StatusCodes.Status200OK, "Room Assignment Updated Successfully!");
        }

        [HasPermission<HospitalFacilityPermissions>(HospitalFacilityPermissions.RoomAssignmentsDelete)]
        [HttpDelete("{ID}", Name = "DeleteRoomAssignmentAsync")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteAsync([FromRoute] int ID)
        {
            DeleteRoomAssignmentRequest deleteRoomAssignmentRequest = new DeleteRoomAssignmentRequest
            {
                Id = ID
            };
            var success = await _sender.Send(deleteRoomAssignmentRequest);
            return CreateResponse<bool>(success, StatusCodes.Status200OK, "Room Assignment Deleted Successfully!");
        }
    }
}