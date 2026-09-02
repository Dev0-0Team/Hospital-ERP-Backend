using Azure;
using Hospital_ERP_Backend.Application.Features.Users.Commands.CreateUser;
using Hospital_ERP_Backend.Application.Features.Users.Commands.DeleteUser;
using Hospital_ERP_Backend.Application.Features.Users.Commands.UpdateUser;
using Hospital_ERP_Backend.Application.Features.Users.Queries.GetAllUsers;
using Hospital_ERP_Backend.Application.Features.Users.Queries.GetUser;
using MediatR;
using Hospital_ERP_Backend.Application.Security.Authorization;
using Hospital_ERP_Backend.Domain.Enums.PermissionBits;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_ERP_Backend.API.Controllers
{
    [Route("api/Users")]
    [ApiController]
    [Authorize]
    public class UsersController : BaseController
    {
        private readonly ISender _sender;

        public UsersController
            (ISender sender)
        {
            _sender = sender;
        }

        [HasPermission<SecurityPermissions>(SecurityPermissions.UserRead)]
        [HttpGet(Name = "GetAllUsersAsync")]
        public async Task<ActionResult<ApiResponse<IEnumerable<GetAllUsersResponse>?>>> GetAllAsync([FromQuery] int page = 1)
        {
            GetAllUsersRequest getAllUsers = new GetAllUsersRequest
            {
                Page = page
            };

            var list = await _sender.Send(getAllUsers);
            return CreateResponse<IEnumerable<GetAllUsersResponse>?>(list, StatusCodes.Status200OK, $"Row: {list.Count()}");
        }


        [HasPermission<SecurityPermissions>(SecurityPermissions.UserRead)]
        [HttpGet("{ID}", Name = "GetUserByID")]
        public async Task<ActionResult<ApiResponse<GetUserResponse?>>> GetByIDAsync([FromRoute] int ID)
        {
            GetUserRequest getUserRequest = new GetUserRequest
            {
                Id = ID
            };
            var response = await _sender.Send(getUserRequest);
            return CreateResponse<GetUserResponse?>(response, StatusCodes.Status200OK, "Found Successfully!");
        }

        [HasPermission<SecurityPermissions>(SecurityPermissions.UserCreate)]
        [HttpPost(Name = "CreateUserAsync")]
        public async Task<ActionResult<ApiResponse<CreateUserResponse>>> CreateAsync([FromBody] CreateUserRequest request)
        {

            var success = await _sender.Send(request);
            return CreatedAtRoute("GetUserByID", new { ID = success!.Id },
                new ApiResponse<CreateUserResponse>
                {
                    statusCode = StatusCodes.Status201Created,
                    message = "User Created Successfully!",
                    data = success
                });
        }

        [HasPermission<SecurityPermissions>(SecurityPermissions.UserUpdate)]
        [HttpPut(Name = "UpdateUserAsync")]
        public async Task<ActionResult<ApiResponse<UpdateUserResponse>>> UpdateAsync([FromBody] UpdateUserRequest request)
        {
            var response = await _sender.Send(request);
            return CreateResponse<UpdateUserResponse>(response, StatusCodes.Status200OK, "User Updated Successfully!");
        }

        [HasPermission<SecurityPermissions>(SecurityPermissions.UserDelete)]
        [HttpDelete("{ID}", Name = "DeleteUserAsync")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteAsync([FromRoute] int ID)
        {
            DeleteUserRequest deleteUserRequest = new DeleteUserRequest
            {
                Id = ID
            };
            var success = await _sender.Send(deleteUserRequest);
            return CreateResponse<bool>(success, StatusCodes.Status200OK, "User Deleted Successfully!");
        }

    }
}
