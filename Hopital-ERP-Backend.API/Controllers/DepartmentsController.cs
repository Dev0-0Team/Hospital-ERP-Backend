using Hospital_ERP_Backend.API;
using Hospital_ERP_Backend.API.Controllers;
using Hospital_ERP_Backend.Application.Features.Departments.Commands.CreateDepartment;
using Hospital_ERP_Backend.Application.Features.Departments.Commands.DeleteDepartment;
using Hospital_ERP_Backend.Application.Features.Departments.Commands.UpdateDepartment;
using Hospital_ERP_Backend.Application.Features.Departments.Queries.GetAllDepartments;
using Hospital_ERP_Backend.Application.Features.Departments.Queries.GetDepartment;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hopital_ERP_Backend.API.Controllers
{
    [Route("api/Departments")]
    [ApiController]
    public class DepartmentsController : BaseController
    {
        private readonly ISender _sender;

        public DepartmentsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet(Name = "GetAllDepartmentsAsync")]
        public async Task<ActionResult<ApiResponse<IEnumerable<GetAllDepartmentsResponse>?>>>GetAllAsync([FromQuery] int page = 1)
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
                response);
        }

        [HttpPut(Name = "UpdateDepartmentAsync")]
        public async Task<ActionResult<ApiResponse<UpdateDepartmentResponse>>> UpdateAsync([FromBody] UpdateDepartmentRequest request)
        {
            var response = await _sender.Send(request);

            return CreateResponse(
                response,
                StatusCodes.Status200OK,
                "Department updated successfully!");
        }

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
