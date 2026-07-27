using Hospital_ERP_Backend.Application.Features.RolePermissions.Command.CreateRolePermission;
using Hospital_ERP_Backend.Application.Features.RolePermissions.Command.DeleteRolePermission;
using Hospital_ERP_Backend.Application.Features.RolePermissions.Command.UpdateRolePermission;
using Hospital_ERP_Backend.Application.Features.RolePermissions.Query.GetAllRolePermissions;
using Hospital_ERP_Backend.Application.Features.RolePermissions.Query.GetRolePermissions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_ERP_Backend.API.Controllers
{
    [Route("api/RolePermissions")]
    [ApiController]
    public class RolePermissionsController : BaseController
    {
        private readonly ISender _sender;

        public RolePermissionsController
            (ISender sender)
        {
            _sender = sender;
        }


        [HttpGet(Name = "GetAllRolePermissionsAsync")]
        public async Task<ActionResult<ApiResponse<IEnumerable<GetAllRolePermissionsResponse>?>>> GetAllAsync([FromQuery] int page = 1)
        {
            GetAllRolePermissionsRequest getAllRolePermissions = new GetAllRolePermissionsRequest
            {
                Page = page
            };

            var list = await _sender.Send(getAllRolePermissions);
            return CreateResponse<IEnumerable<GetAllRolePermissionsResponse>?>(list, StatusCodes.Status200OK, $"Row: {list.Count()}");
        }


        [HttpGet("{ID}", Name = "GetRolePermissionByID")]
        public async Task<ActionResult<ApiResponse<GetRolePermissionResponse?>>> GetByIDAsync([FromRoute] int ID)
        {
            GetRolePermissionRequest getRolePermissionRequest = new GetRolePermissionRequest
            {
                Id = ID
            };
            var response = await _sender.Send(getRolePermissionRequest);
            return CreateResponse<GetRolePermissionResponse?>(response, StatusCodes.Status200OK, "Found Successfully!");
        }

        [HttpPost(Name = "CreateRolePermissionAsync")]
        public async Task<ActionResult<ApiResponse<CreateRolePermissionResponse>>> CreateAsync([FromBody] CreateRolePermissionRequest request)
        {

            var success = await _sender.Send(request);
            return CreatedAtRoute("GetRolePermissionByID", new { ID = success!.Id }, success);
        }

        [HttpPut(Name = "UpdateRolePermissionAsync")]
        public async Task<ActionResult<ApiResponse<UpdateRolePermissionResponse>>> UpdateAsync([FromBody] UpdateRolePermissionRequest request)
        {
            var response = await _sender.Send(request);
            return CreateResponse<UpdateRolePermissionResponse>(response, StatusCodes.Status200OK, "Role Permission Updated Successfully!");
        }

        [HttpDelete("{ID}", Name = "DeleteRolePermissionAsync")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteAsync([FromRoute] int ID)
        {
            DeleteRolePermissionRequest deleteRolePermissionRequest = new DeleteRolePermissionRequest
            {
                Id = ID
            };

            var success = await _sender.Send(deleteRolePermissionRequest);
            return CreateResponse<bool>(success, StatusCodes.Status200OK, "Role Permission Deleted Successfully!");
        }

    }
}
