using Hospital_ERP_Backend.API;
using Hospital_ERP_Backend.API.Controllers;
using Hospital_ERP_Backend.Application.Features.Users.Commands.CreateUser;
using Hospital_ERP_Backend.Application.Features.Users.Commands.DeleteUser;
using Hospital_ERP_Backend.Application.Features.Users.Commands.UpdateUser;
using Hospital_ERP_Backend.Application.Features.Users.Queries.GetAllUsers;
using Hospital_ERP_Backend.Application.Features.Users.Queries.GetUser;
using Microsoft.AspNetCore.Mvc;

namespace Hopital_ERP_Backend.API.Controllers
{
    [Route("api/Users")]
    [ApiController]
    public class UsersController : BaseController
    {
        private readonly GetAllUsersService _getAllUser;
        private readonly GetUserService _getUser;
        private readonly CreateUserService _createUser;
        private readonly UpdateUserService _updateUser;
        private readonly DeleteUserService _deleteUser;

        public UsersController
            (GetAllUsersService getAllUser, GetUserService getUser, CreateUserService createUser,
            UpdateUserService updateUser, DeleteUserService deleteUser)
        {
            _getAllUser = getAllUser;
            _getUser = getUser;
            _createUser = createUser;
            _updateUser = updateUser;
            _deleteUser = deleteUser;
        }

        [HttpGet(Name = "GetAllUsersAsync")]
        public async Task<ActionResult<ApiResponse<IEnumerable<GetAllUsersResponse>?>>> GetAllAsync([FromQuery] int page = 1)
        {
            GetAllUsersRequest getAllUsers = new GetAllUsersRequest
            {
                Page = page
            };

            var list = await _getAllUser.GetAllUsersAsync(getAllUsers);
            return CreateResponse<IEnumerable<GetAllUsersResponse>?>(list, StatusCodes.Status200OK, $"Row: {list.Count()}");
        }


        [HttpGet("{ID}", Name = "GetUserByID")]
        public async Task<ActionResult<ApiResponse<GetUserResponse?>>> GetByIDAsync([FromRoute] int ID)
        {
            GetUserRequest getUserRequest = new GetUserRequest
            {
                Id = ID
            };
            var response = await _getUser.GetUserAsync(getUserRequest);
            return CreateResponse<GetUserResponse?>(response, StatusCodes.Status200OK, "Found Successfully!");
        }

        [HttpPost(Name = "CreateUserAsync")]
        public async Task<ActionResult<ApiResponse<CreateUserResponse>>> CreateAsync([FromBody] CreateUserRequest request)
        {

            var success = await _createUser.CreateUserAsync(request);
            return CreatedAtRoute("GetUserByID", new { ID = success!.Id }, success);
        }

        [HttpPut(Name = "UpdateUserAsync")]
        public async Task<ActionResult<ApiResponse<UpdateUserResponse>>> UpdateAsync([FromBody] UpdateUserRequest request)
        {
            var response = await _updateUser.UpdateUserAsync(request);
            return CreateResponse<UpdateUserResponse>(response, StatusCodes.Status200OK, "User Updated Successfully!");
        }

        [HttpDelete("{ID}", Name = "DeleteUserAsync")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteAsync([FromRoute] int ID)
        {
            DeleteUserRequest deleteUserRequest = new DeleteUserRequest
            {
                Id = ID
            };
            var success = await _deleteUser.DeleteUserAsync(deleteUserRequest);
            return CreateResponse<bool>(success, StatusCodes.Status200OK, "User Deleted Successfully!");
        }

    }
}
