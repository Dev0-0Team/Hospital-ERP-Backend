using Azure;
using Hospital_ERP_Backend.Application.Features.UserRoles.Commands.CreateUserRole;
using Hospital_ERP_Backend.Application.Features.UserRoles.Commands.DeleteUserRole;
using Hospital_ERP_Backend.Application.Features.UserRoles.Commands.UpdateUserRole;
using Hospital_ERP_Backend.Application.Features.UserRoles.Queries.GetAllUserRoles;
using Hospital_ERP_Backend.Application.Features.UserRoles.Queries.GetUserRoles;
using MediatR;
using Hospital_ERP_Backend.Application.Security.Authorization;
using Hospital_ERP_Backend.Domain.Enums.PermissionBits;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_ERP_Backend.API.Controllers
{
    [Route("api/UserRoles")]
    [ApiController]
    [Authorize]
    public class UserRolesController : BaseController
    {
        private readonly ISender _sender;

        public UserRolesController
            (ISender sender)
        {
            _sender = sender;
        }

        [HasPermission<SecurityPermissions>(SecurityPermissions.UserRolesRead)]
        [HttpGet(Name = "GetAllUserRolesAsync")]
        public async Task<ActionResult<ApiResponse<IEnumerable<GetAllUserRolesResponse>?>>> GetAllAsync([FromQuery] int page = 1)
        {
            GetAllUserRolesRequest getAllUserRoles = new GetAllUserRolesRequest
            {
                Page = page
            };

            var list = await _sender.Send(getAllUserRoles);
            return CreateResponse<IEnumerable<GetAllUserRolesResponse>?>(list, StatusCodes.Status200OK, $"Row: {list.Count()}");
        }


        [HasPermission<SecurityPermissions>(SecurityPermissions.UserRolesRead)]
        [HttpGet("{ID}", Name = "GetUserRoleByID")]
        public async Task<ActionResult<ApiResponse<GetUserRoleResponse?>>> GetByIDAsync([FromRoute] int ID)
        {
            GetUserRoleRequest getUserRoleRequest = new GetUserRoleRequest
            {
                Id = ID
            };
            var response = await _sender.Send(getUserRoleRequest);
            return CreateResponse<GetUserRoleResponse?>(response, StatusCodes.Status200OK, "Found Successfully!");
        }

        [HasPermission<SecurityPermissions>(SecurityPermissions.UserRolesCreate)]
        [HttpPost(Name = "CreateUserRoleAsync")]
        public async Task<ActionResult<ApiResponse<CreateUserRoleResponse>>> CreateAsync([FromBody] CreateUserRoleRequest request)
        {

            var success = await _sender.Send(request);
            return CreatedAtRoute("GetUserRoleByID", new { ID = success!.Id },
                new ApiResponse<CreateUserRoleResponse>
                {
                    statusCode = StatusCodes.Status201Created,
                    message = "User Role Created Successfully!",
                    data = success
                });
        }

        [HasPermission<SecurityPermissions>(SecurityPermissions.UserRolesUpdate)]
        [HttpPut(Name = "UpdateUserRoleAsync")]
        public async Task<ActionResult<ApiResponse<UpdateUserRoleResponse>>> UpdateAsync([FromBody] UpdateUserRoleRequest request)
        {
            var response = await _sender.Send(request);
            return CreateResponse<UpdateUserRoleResponse>(response, StatusCodes.Status200OK, "User Role Updated Successfully!");
        }

        [HasPermission<SecurityPermissions>(SecurityPermissions.UserRolesDelete)]
        [HttpDelete("{ID}", Name = "DeleteUserRoleAsync")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteAsync([FromRoute] int ID)
        {
            DeleteUserRoleRequest deleteUserRoleRequest = new DeleteUserRoleRequest
            {
                Id = ID
            };
            var success = await _sender.Send(deleteUserRoleRequest);
            return CreateResponse<bool>(success, StatusCodes.Status200OK, "User Role Deleted Successfully!");
        }

    }
}
