using Hospital_ERP_Backend.API;
using Hospital_ERP_Backend.API.Controllers;
using Hospital_ERP_Backend.Application.Features.Permissions.Commands.CreatePermission;
using Hospital_ERP_Backend.Application.Features.Permissions.Commands.DeletePermission;
using Hospital_ERP_Backend.Application.Features.Permissions.Commands.UpdatePermission;
using Hospital_ERP_Backend.Application.Features.Permissions.Queries.GetAllPermissions;
using Hospital_ERP_Backend.Application.Features.Permissions.Queries.GetPermission;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hopital_ERP_Backend.API.Controllers
{
    [Route("api/Permissions")]
    [ApiController]
    public class PermissionsController : BaseController
    {
        private readonly ISender _sender;

        public PermissionsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet(Name = "GetAllPermissionsAsync")]
        public async Task<ActionResult<ApiResponse<IEnumerable<GetAllPermissionsResponse>?>>> GetAllAsync([FromQuery] int page = 1)
        {
            GetAllPermissionsRequest getAllPermissions = new GetAllPermissionsRequest()
            {
                Page = page
            };

            var list = await _sender.Send(getAllPermissions);
            return CreateResponse<IEnumerable<GetAllPermissionsResponse>?>(list, StatusCodes.Status200OK, $"Row: {list.Count()}");
        }


        [HttpGet("{ID}", Name = "GetPermissionByID")]
        public async Task<ActionResult<ApiResponse<GetPermissionResponse?>>> GetByIDAsync([FromRoute] int ID)
        {
            GetPermissionRequest getPermissionRequest = new GetPermissionRequest
            {
                Id = ID
            };
            var response = await _sender.Send(getPermissionRequest);
            return CreateResponse<GetPermissionResponse?>(response, StatusCodes.Status200OK, "Found Successfully!");
        }

        [HttpPost(Name = "CreatePermissionAsync")]
        public async Task<ActionResult<ApiResponse<CreatePermissionResponse>>> CreateAsync([FromBody] CreatePermissionRequest request)
        {

            var success = await _sender.Send(request);
            return CreatedAtRoute("GetPermissionByID", new { ID = success!.Id }, success);
        }

        [HttpPut(Name = "UpdatePermissionAsync")]
        public async Task<ActionResult<ApiResponse<UpdatePermissionResponse>>> UpdateAsync([FromBody] UpdatePermissionRequest request)
        {
            var response = await _sender.Send(request);
            return CreateResponse<UpdatePermissionResponse>(response, StatusCodes.Status200OK, "Permission Updated Successfully!");
        }

        [HttpDelete("{ID}", Name = "DeletePermissionAsync")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteAsync([FromRoute] int ID)
        {
            DeletePermissionRequest deletePermissionRequest = new DeletePermissionRequest
            {
                Id = ID
            };
            var success = await _sender.Send(deletePermissionRequest);
            return CreateResponse<bool>(success, StatusCodes.Status200OK, "Permission Deleted Successfully!");
        }
    }
}
