using Hospital_ERP_Backend.Application.Features.Doctors.Commands.CreateDoctor;
using Hospital_ERP_Backend.Application.Features.Doctors.Commands.DeleteDoctor;
using Hospital_ERP_Backend.Application.Features.Doctors.Commands.UpdateDoctor;
using Hospital_ERP_Backend.Application.Features.Doctors.Queries.GetAllDoctors;
using Hospital_ERP_Backend.Application.Features.Doctors.Queries.GetDoctor;
using Hospital_ERP_Backend.Application.Security.Authorization;
using Hospital_ERP_Backend.Domain.Enums.PermissionBits;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_ERP_Backend.API.Controllers
{
    [Route("api/Doctors")]
    [ApiController]
    [Authorize]
    public class DoctorsController : BaseController
    {
        private readonly ISender _sender;

        public DoctorsController(ISender sender)
        {
            _sender = sender;
        }

        [HasPermission<StaffManagementPermissions>(StaffManagementPermissions.DoctorsRead)]
        [HttpGet(Name = "GetAllDoctorsAsync")]
        public async Task<ActionResult<ApiResponse<IEnumerable<GetAllDoctorsResponse>?>>> GetAllAsync([FromQuery] int page = 1)
        {
            GetAllDoctorsRequest request = new()
            {
                Page = page
            };

            var list = await _sender.Send(request);

            return CreateResponse<IEnumerable<GetAllDoctorsResponse>?>(
                list,
                StatusCodes.Status200OK,
                $"Rows: {list.Count()}");
        }

        [HasPermission<StaffManagementPermissions>(StaffManagementPermissions.DoctorsRead)]
        [HttpGet("{ID:int}", Name = "GetDoctorByIdAsync")]
        public async Task<ActionResult<ApiResponse<GetDoctorResponse?>>> GetByIdAsync([FromRoute] int ID)
        {
            GetDoctorRequest request = new()
            {
                Id = ID
            };

            var result = await _sender.Send(request);

            return CreateResponse<GetDoctorResponse?>(
                result,
                StatusCodes.Status200OK,
                "Doctor found successfully!");
        }

        [HasPermission<StaffManagementPermissions>(StaffManagementPermissions.DoctorsCreate)]
        [HttpPost(Name = "CreateDoctorAsync")]
        public async Task<ActionResult<ApiResponse<CreateDoctorResponse>>> CreateAsync([FromBody] CreateDoctorRequest request)
        {
            var response = await _sender.Send(request);

            return CreatedAtRoute(
                "GetDoctorByIdAsync",
                new
                {
                    ID = response.Id
                },
                new ApiResponse<CreateDoctorResponse>
                {
                    statusCode = StatusCodes.Status201Created,
                    message = "Doctor Created Successfully!",
                    data = response
                }
                );
        }

        [HasPermission<StaffManagementPermissions>(StaffManagementPermissions.DoctorsUpdate)]
        [HttpPut(Name = "UpdateDoctorAsync")]
        public async Task<ActionResult<ApiResponse<UpdateDoctorResponse>>> UpdateAsync([FromBody] UpdateDoctorRequest request)
        {
            var response = await _sender.Send(request);

            return CreateResponse(
                response,
                StatusCodes.Status200OK,
                "Doctor updated successfully!");
        }

        [HasPermission<StaffManagementPermissions>(StaffManagementPermissions.DoctorsDelete)]
        [HttpDelete("{ID:int}", Name = "DeleteDoctorAsync")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteAsync([FromRoute] int ID)
        {
            DeleteDoctorRequest request = new()
            {
                Id = ID
            };

            var success = await _sender.Send(request);

            return CreateResponse(
                success,
                StatusCodes.Status200OK,
                "Doctor deleted successfully!");
        }
    }
}