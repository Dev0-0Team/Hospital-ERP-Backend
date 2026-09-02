
using Hospital_ERP_Backend.Application.Features.Departments.Commands.CreateDepartment;
using Hospital_ERP_Backend.Application.Features.Departments.Commands.DeleteDepartment;
using Hospital_ERP_Backend.Application.Features.Departments.Commands.UpdateDepartment;
using Hospital_ERP_Backend.Application.Features.Departments.Queries.GetAllDepartments;
using Hospital_ERP_Backend.Application.Features.Departments.Queries.GetDepartment;
using Hospital_ERP_Backend.Application.Security.Authorization;
using Hospital_ERP_Backend.Domain.Enums.PermissionBits;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_ERP_Backend.API.Controllers
{
    [Route("api/Departments")]
    [ApiController]
    [Authorize]
    public class DepartmentsController : BaseController
    {
        private readonly ISender _sender;

        public DepartmentsController(ISender sender)
        {
            _sender = sender;
        }

        [HasPermission<StaffManagementPermissions>(StaffManagementPermissions.DepartmentsRead)]
        [HttpGet(Name = "GetAllDepartmentsAsync")]
        public async Task<ActionResult<ApiResponse<IEnumerable<GetAllDepartmentsResponse>?>>> GetAllAsync([FromQuery] int page = 1)
        {
            GetAllDepartmentsRequest request = new()
            {
                Page = page
            };

            var list = await _sender.Send(request);

            return CreateResponse<IEnumerable<GetAllDepartmentsResponse>?>(
                list,
                StatusCodes.Status200OK,
                $"Rows: {list.Count()}");
        }

        [HasPermission<StaffManagementPermissions>(StaffManagementPermissions.DepartmentsRead)]
        [HttpGet("{ID:int}", Name = "GetDepartmentByIdAsync")]
        public async Task<ActionResult<ApiResponse<GetDepartmentResponse?>>> GetByIdAsync([FromRoute] int ID)
        {
            GetDepartmentRequest request = new()
            {
                Id = ID
            };

            var department = await _sender.Send(request);

            return CreateResponse<GetDepartmentResponse?>(
                department,
                StatusCodes.Status200OK,
                "Department found successfully!");
        }

        [HasPermission<StaffManagementPermissions>(StaffManagementPermissions.DepartmentsCreate)]
        [HttpPost(Name = "CreateDepartmentAsync")]
        public async Task<ActionResult<ApiResponse<CreateDepartmentResponse>>> CreateAsync([FromBody] CreateDepartmentRequest request)
        {
            var response = await _sender.Send(request);

            return CreatedAtRoute(
                "GetDepartmentByIdAsync",
                new
                {
                    ID = response.Id
                },
                new ApiResponse<CreateDepartmentResponse>
                {
                    statusCode = StatusCodes.Status201Created,
                    message = "Department Created Successfully!",
                    data = response
                });
        }

        [HasPermission<StaffManagementPermissions>(StaffManagementPermissions.DepartmentsUpdate)]
        [HttpPut(Name = "UpdateDepartmentAsync")]
        public async Task<ActionResult<ApiResponse<UpdateDepartmentResponse>>> UpdateAsync([FromBody] UpdateDepartmentRequest request)
        {
            var response = await _sender.Send(request);

            return CreateResponse(
                response,
                StatusCodes.Status200OK,
                "Department updated successfully!");
        }

        [HasPermission<StaffManagementPermissions>(StaffManagementPermissions.DepartmentsDelete)]
        [HttpDelete("{ID:int}", Name = "DeleteDepartmentAsync")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteAsync([FromRoute] int ID)
        {
            DeleteDepartmentRequest request = new()
            {
                Id = ID
            };

            var success = await _sender.Send(request);

            return CreateResponse(
                success,
                StatusCodes.Status200OK,
                "Department deleted successfully!");
        }
    }
}
