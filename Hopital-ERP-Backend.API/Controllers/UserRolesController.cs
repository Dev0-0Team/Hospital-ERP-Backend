using Hospital_ERP_Backend.API;
using Hospital_ERP_Backend.API.Controllers;
using Hospital_ERP_Backend.Application.Features.UserRoles.Commands.CreateUserRole;
using Hospital_ERP_Backend.Application.Features.UserRoles.Commands.DeleteUserRole;
using Hospital_ERP_Backend.Application.Features.UserRoles.Commands.UpdateUserRole;
using Hospital_ERP_Backend.Application.Features.UserRoles.Queries.GetAllUserRoles;
using Hospital_ERP_Backend.Application.Features.UserRoles.Queries.GetUserRoles;
using Microsoft.AspNetCore.Mvc;

namespace Hopital_ERP_Backend.API.Controllers
{
    [Route("api/UserRoles")]
    [ApiController]
    public class UserRolesController : BaseController
    {
        private readonly GetAllUserRolesService _getAllUserRoles;
        private readonly GetUserRoleService _getUserRole;
        private readonly CreateUserRoleService _createUserRole;
        private readonly UpdateUserRoleService _updateUserRole;
        private readonly DeleteUserRoleService _deleteUserRole;

        public UserRolesController
            (GetAllUserRolesService getAllUserRoles, GetUserRoleService getUserRole, CreateUserRoleService createUserRole,
            UpdateUserRoleService updateUserRole, DeleteUserRoleService deleteUserRole)
        {
            _getAllUserRoles = getAllUserRoles;
            _getUserRole = getUserRole;
            _createUserRole = createUserRole;
            _updateUserRole = updateUserRole;
            _deleteUserRole = deleteUserRole;
        }

        [HttpGet(Name = "GetAllUserRolesAsync")]
        public async Task<ActionResult<ApiResponse<IEnumerable<GetAllUserRolesResponse>?>>> GetAllAsync([FromQuery] int page = 1)
        {
            GetAllUserRolesRequest getAllUserRoles = new GetAllUserRolesRequest
            {
                Page = page
            };

            var list = await _getAllUserRoles.GetAllUserRolesAsync(getAllUserRoles);
            return CreateResponse<IEnumerable<GetAllUserRolesResponse>?>(list, StatusCodes.Status200OK, $"Row: {list.Count()}");
        }


        [HttpGet("{ID}", Name = "GetUserRoleByID")]
        public async Task<ActionResult<ApiResponse<GetUserRoleResponse?>>> GetByIDAsync([FromRoute] int ID)
        {
            GetUserRoleRequest getUserRoleRequest = new GetUserRoleRequest
            {
                Id = ID
            };
            var response = await _getUserRole.GetUserRoleAsync(getUserRoleRequest);
            return CreateResponse<GetUserRoleResponse?>(response, StatusCodes.Status200OK, "Found Successfully!");
        }

        [HttpPost(Name = "CreateUserRoleAsync")]
        public async Task<ActionResult<ApiResponse<CreateUserRoleResponse>>> CreateAsync([FromBody] CreateUserRoleRequest request)
        {

            var success = await _createUserRole.CreateUserRoleAsync(request);
            return CreatedAtRoute("GetUserRoleByID", new { ID = success!.Id }, success);
        }

        [HttpPut(Name = "UpdateUserRoleAsync")]
        public async Task<ActionResult<ApiResponse<UpdateUserRoleResponse>>> UpdateAsync([FromBody] UpdateUserRoleRequest request)
        {
            var response = await _updateUserRole.UpdateUserRoleAsync(request);
            return CreateResponse<UpdateUserRoleResponse>(response, StatusCodes.Status200OK, "User Role Updated Successfully!");
        }

        [HttpDelete("{ID}", Name = "DeleteUserRoleAsync")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteAsync([FromRoute] int ID)
        {
            DeleteUserRoleRequest deleteUserRoleRequest = new DeleteUserRoleRequest
            {
                Id = ID
            };
            var success = await _deleteUserRole.DeleteUserRoleAsync(deleteUserRoleRequest);
            return CreateResponse<bool>(success, StatusCodes.Status200OK, "User Role Deleted Successfully!");
        }

    }
}
