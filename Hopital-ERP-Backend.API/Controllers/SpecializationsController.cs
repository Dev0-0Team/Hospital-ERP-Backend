using Hospital_ERP_Backend.Application.Features.Specializations.Commands.CreateSpecialization;
using Hospital_ERP_Backend.Application.Features.Specializations.Commands.DeleteSpecialization;
using Hospital_ERP_Backend.Application.Features.Specializations.Commands.UpdateSpecialization;
using Hospital_ERP_Backend.Application.Features.Specializations.Queries.GetAllSpecializations;
using Hospital_ERP_Backend.Application.Features.Specializations.Queries.GetSpecialization;
using MediatR;
using Hospital_ERP_Backend.Application.Security.Authorization;
using Hospital_ERP_Backend.Domain.Enums.PermissionBits;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_ERP_Backend.API.Controllers
{
    [Route("api/Specializations")]
    [ApiController]
    [Authorize]
    public class SpecializationsController : BaseController
    {
        private readonly ISender _sender;

        public SpecializationsController(ISender sender)
        {
            _sender = sender;
        }

        [HasPermission<StaffManagementPermissions>(StaffManagementPermissions.SpecializationsRead)]
        [HttpGet(Name = "GetAllSpecializationsAsync")]
        public async Task<ActionResult<ApiResponse<IEnumerable<GetAllSpecializationsResponse>?>>> GetAllAsync([FromQuery] int page = 1)
        {
            GetAllSpecializationsRequest newRequest = new GetAllSpecializationsRequest
            {
                Page = page
            };

            var list = await _sender.Send(newRequest);
            return CreateResponse<IEnumerable<GetAllSpecializationsResponse>?>(list, StatusCodes.Status200OK, $"Row: {list.Count()}");
        }

        [HasPermission<StaffManagementPermissions>(StaffManagementPermissions.SpecializationsRead)]
        [HttpGet("{ID}", Name = "GetSpecializationByID")]
        public async Task<ActionResult<ApiResponse<GetSpecializationResponse?>>> GetByIDAsync([FromRoute] int ID)
        {
            GetSpecializationRequest newRequest = new GetSpecializationRequest
            {
                Id = ID
            };
            var response = await _sender.Send(newRequest);
            return CreateResponse<GetSpecializationResponse?>(response, StatusCodes.Status200OK, "Found Successfully!");
        }

        [HasPermission<StaffManagementPermissions>(StaffManagementPermissions.SpecializationsCreate)]
        [HttpPost(Name = "CreateSpecializationAsync")]
        public async Task<ActionResult<ApiResponse<CreateSpecializationResponse>>> CreateAsync([FromBody] CreateSpecializationRequest request)
        {
            var success = await _sender.Send(request);
            return CreatedAtRoute
                ("GetSpecializationByID",
                new { ID = success!.Id },
                new ApiResponse<CreateSpecializationResponse>
                {
                    statusCode = StatusCodes.Status201Created,
                    message = "Specialization Created Successfully!",
                    data = success
                });
        }

        [HasPermission<StaffManagementPermissions>(StaffManagementPermissions.SpecializationsUpdate)]
        [HttpPut(Name = "UpdateSpecializationAsync")]
        public async Task<ActionResult<ApiResponse<UpdateSpecializationResponse>>> UpdateAsync([FromBody] UpdateSpecializationRequest request)
        {
            var response = await _sender.Send(request);
            return CreateResponse<UpdateSpecializationResponse>(response, StatusCodes.Status200OK, "Specialization Updated Successfully!");
        }

        [HasPermission<StaffManagementPermissions>(StaffManagementPermissions.SpecializationsDelete)]
        [HttpDelete("{ID}", Name = "DeleteSpecializationAsync")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteAsync([FromRoute] int ID)
        {
            DeleteSpecializationRequest newRequest = new DeleteSpecializationRequest
            {
                Id = ID
            };
            var success = await _sender.Send(newRequest);
            return CreateResponse<bool>(success, StatusCodes.Status200OK, "Specialization Deleted Successfully!");
        }
    }
}
