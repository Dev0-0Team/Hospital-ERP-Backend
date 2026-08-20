using Hospital_ERP_Backend.Application.Features.AdministrativeStaffs.Commands.CreateAdministrativeStaff;
using Hospital_ERP_Backend.Application.Features.AdministrativeStaffs.Commands.DeleteAdministrativeStaff;
using Hospital_ERP_Backend.Application.Features.AdministrativeStaffs.Commands.UpdateAdministrativeStaff;
using Hospital_ERP_Backend.Application.Features.AdministrativeStaffs.Queries.GetAdministrativeStaff;
using Hospital_ERP_Backend.Application.Features.AdministrativeStaffs.Queries.GetAllAdministrativeStaffs;
using Hospital_ERP_Backend.Application.Security.Authorization;
using Hospital_ERP_Backend.Domain.Enums.PermissionBits;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_ERP_Backend.API.Controllers
{
    [Route("AdministrativeStaffs")]
    [ApiController]
    [Authorize]
    public class AdministrativeStaffsController : BaseController
    {
        private readonly ISender _sender;
        public AdministrativeStaffsController(ISender sender)
        {
            _sender = sender;
        }
        [HasPermission<StaffManagementPermissions>(StaffManagementPermissions.AdministrativeStaffRead)]
        [HttpGet(Name = "GetAllAdministrativeStaffsAsync")]
        public async Task<ActionResult<ApiResponse<IEnumerable<GetAllAdministrativeStaffsResponse>?>>> GetAllAsync([FromQuery] int page = 1)
        {
            GetAllAdministrativeStaffsRequest request = new()
            {
                Page = page
            };

            var list = await _sender.Send(request);

            return CreateResponse<IEnumerable<GetAllAdministrativeStaffsResponse>?>(
                list,
                StatusCodes.Status200OK,
                $"Rows: {list.Count()}");
        }

        [HasPermission<StaffManagementPermissions>(StaffManagementPermissions.AdministrativeStaffRead)]
        [HttpGet("{ID:int}", Name = "GetAdministrativeStaffByIdAsync")]
        public async Task<ActionResult<ApiResponse<GetAdministrativeStaffResponse?>>> GetByIdAsync([FromRoute] int ID)
        {
            GetAdministrativeStaffRequest request = new()
            {
                Id = ID
            };

            var appointmentQueue = await _sender.Send(request);

            return CreateResponse<GetAdministrativeStaffResponse?>(
                appointmentQueue,
                StatusCodes.Status200OK,
                "Administrative Staff found successfully!");
        }

        [HasPermission<StaffManagementPermissions>(StaffManagementPermissions.AdministrativeStaffCreate)]
        [HttpPost(Name = "CreateAdministrativeStaffAsync")]
        public async Task<ActionResult<ApiResponse<CreateAdministrativeStaffResponse>>> CreateAsync([FromBody] CreateAdministrativeStaffRequest request)
        {
            CreateAdministrativeStaffResponse response = await _sender.Send(request);

            return CreatedAtRoute(
                "GetAdministrativeStaffByIdAsync",
                new
                {
                    ID = response.Id
                },
                new ApiResponse<CreateAdministrativeStaffResponse>
                {
                    statusCode = StatusCodes.Status201Created,
                    Message = "Administrative Staff Created Successfully!",
                    Data = response
                });
        }

        [HasPermission<StaffManagementPermissions>(StaffManagementPermissions.AdministrativeStaffUpdate)]
        [HttpPut(Name = "UpdateAdministrativeStaffAsync")]
        public async Task<ActionResult<ApiResponse<UpdateAdministrativeStaffResponse>>> UpdateAsync([FromBody] UpdateAdministrativeStaffRequest request)
        {
            UpdateAdministrativeStaffResponse response = await _sender.Send(request);

            return CreateResponse(
                response,
                StatusCodes.Status200OK,
                "Administrative Staff updated successfully!");
        }

        [HasPermission<StaffManagementPermissions>(StaffManagementPermissions.AdministrativeStaffDelete)]
        [HttpDelete("{ID:int}", Name = "DeleteAdministrativeStaffAsync")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteAsync([FromRoute] int ID)
        {
            DeleteAdministrativeStaffRequest request = new()
            {
                Id = ID
            };

            var success = await _sender.Send(request);

            return CreateResponse(
                success,
                StatusCodes.Status200OK,
                "Administrative Staff deleted successfully!");
        }
    }
}