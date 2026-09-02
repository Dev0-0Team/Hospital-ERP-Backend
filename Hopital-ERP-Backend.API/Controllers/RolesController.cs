using Azure;
using Hospital_ERP_Backend.Application.Features.Roles.Commands.CreateRole;
using Hospital_ERP_Backend.Application.Features.Roles.Commands.DeleteRole;
using Hospital_ERP_Backend.Application.Features.Roles.Commands.UpdateRole;
using Hospital_ERP_Backend.Application.Features.Roles.Queries.GetAllRoles;
using Hospital_ERP_Backend.Application.Features.Roles.Queries.GetRole;
using MediatR;
using Hospital_ERP_Backend.Application.Security.Authorization;
using Hospital_ERP_Backend.Domain.Enums.PermissionBits;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_ERP_Backend.API.Controllers
{
    [Route("api/Roles")]
    [ApiController]
    [Authorize]
    public class RolesController : BaseController
    {
        private readonly ISender _sender;

        public RolesController(ISender sender)
        {
            _sender = sender;
        }

        [HasPermission<SecurityPermissions>(SecurityPermissions.RolesRead)]
        [HttpGet(Name = "GetAllRolesAsync")]
        public async Task<ActionResult<ApiResponse<IEnumerable<GetAllRolesResponse>?>>> GetAllAsync([FromQuery] int page = 1)
        {
            GetAllRolesRequest getAllRoles = new GetAllRolesRequest
            {
                Page = page
            };

            var list = await _sender.Send(getAllRoles);
            return CreateResponse<IEnumerable<GetAllRolesResponse>?>(list, StatusCodes.Status200OK, $"Row: {list.Count()}");
        }


        [HasPermission<SecurityPermissions>(SecurityPermissions.RolesRead)]
        [HttpGet("{ID}", Name = "GetRoleByID")]
        public async Task<ActionResult<ApiResponse<GetRoleResponse?>>> GetByIDAsync([FromRoute] int ID)
        {
            GetRoleRequest getRoleRequest = new GetRoleRequest
            {
                Id = ID
            };
            var response = await _sender.Send(getRoleRequest);
            return CreateResponse<GetRoleResponse?>(response, StatusCodes.Status200OK, "Found Successfully!");
        }

        [HasPermission<SecurityPermissions>(SecurityPermissions.RolesCreate)]
        [HttpPost(Name = "CreateRoleAsync")]
        public async Task<ActionResult<ApiResponse<CreateRoleResponse>>> CreateAsync([FromBody] CreateRoleRequest request)
        {

            var success = await _sender.Send(request);
            return CreatedAtRoute("GetRoleByID", new { ID = success!.Id },
                new ApiResponse<CreateRoleResponse>
                {
                    statusCode = StatusCodes.Status201Created,
                    message = "Role Created Successfully!",
                    data = success
                });
        }

        [HasPermission<SecurityPermissions>(SecurityPermissions.RolesUpdate)]
        [HttpPut(Name = "UpdateRoleAsync")]
        public async Task<ActionResult<ApiResponse<UpdateRoleResponse>>> UpdateAsync([FromBody] UpdateRoleRequest request)
        {
            var response = await _sender.Send(request);
            return CreateResponse<UpdateRoleResponse>(response, StatusCodes.Status200OK, "Person Updated Successfully!");
        }

        [HasPermission<SecurityPermissions>(SecurityPermissions.RolesDelete)]
        [HttpDelete("{ID}", Name = "DeleteRoleAsync")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteAsync([FromRoute] int ID)
        {
            DeleteRoleRequest deleteRoleRequest = new DeleteRoleRequest
            {
                Id = ID
            };
            var success = await _sender.Send(deleteRoleRequest);
            return CreateResponse<bool>(success, StatusCodes.Status200OK, "Role Deleted Successfully!");
        }
    }
}
