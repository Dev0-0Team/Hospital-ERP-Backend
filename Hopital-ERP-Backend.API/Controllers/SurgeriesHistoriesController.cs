using Hospital_ERP_Backend.Application.Features.SurgeriesHistories.Commands.CreateSurgeriesHistory;
using Hospital_ERP_Backend.Application.Features.SurgeriesHistories.Commands.DeleteSurgeriesHistory;
using Hospital_ERP_Backend.Application.Features.SurgeriesHistories.Commands.UpdateSurgeriesHistory;
using Hospital_ERP_Backend.Application.Features.SurgeriesHistories.Queries.GetAllSurgeriesHistories;
using Hospital_ERP_Backend.Application.Features.SurgeriesHistories.Queries.GetSurgeriesHistory;
using MediatR;
using Hospital_ERP_Backend.Application.Security.Authorization;
using Hospital_ERP_Backend.Domain.Enums.PermissionBits;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_ERP_Backend.API.Controllers
{
    [ApiController]
    [Route("api/SurgeriesHistories")]
    [Authorize]
    public class SurgeriesHistoriesController : BaseController
    {
        private readonly ISender _sender;
        public SurgeriesHistoriesController(ISender sender)
        {
            _sender = sender;
        }

        [HasPermission<PatientManagementPermissions>(PatientManagementPermissions.SurgeriesHistoryRead)]
        [HttpGet(Name = "GetAllSurgeriesHistoriesAsync")]
        public async Task<ActionResult<ApiResponse<IEnumerable<GetAllSurgeriesHistoriesResponse>?>>> GetAllAsync([FromQuery] int page = 1)
        {
            GetAllSurgeriesHistoriesRequest request = new()
            {
                Page = page
            };

            var list = await _sender.Send(request);

            return CreateResponse<IEnumerable<GetAllSurgeriesHistoriesResponse>?>(
                list,
                StatusCodes.Status200OK,
                $"Rows: {list.Count()}");
        }

        [HasPermission<PatientManagementPermissions>(PatientManagementPermissions.SurgeriesHistoryRead)]
        [HttpGet("{ID:int}", Name = "GetSurgeriesHistoryByIdAsync")]
        public async Task<ActionResult<ApiResponse<GetSurgeriesHistoryResponse?>>> GetByIdAsync([FromRoute] int ID)
        {
            GetSurgeriesHistoryRequest request = new()
            {
                Id = ID
            };

            var result = await _sender.Send(request);

            return CreateResponse<GetSurgeriesHistoryResponse?>(
                result,
                StatusCodes.Status200OK,
                "Surgeries History found successfully!");
        }

        [HasPermission<PatientManagementPermissions>(PatientManagementPermissions.SurgeriesHistoryCreate)]
        [HttpPost(Name = "CreateSurgeriesHistoryAsync")]
        public async Task<ActionResult<ApiResponse<CreateSurgeriesHistoryResponse>>> CreateAsync([FromBody] CreateSurgeriesHistoryRequest request)
        {
            CreateSurgeriesHistoryResponse response = await _sender.Send(request);

            return CreatedAtRoute(
                "GetSurgeriesHistoryByIdAsync",
                new
                {
                    ID = response.Id
                },
                new ApiResponse<CreateSurgeriesHistoryResponse>
                {
                    statusCode = StatusCodes.Status201Created,
                    message = "Surgeries History Created Successfully!",
                    data = response
                });
        }

        [HasPermission<PatientManagementPermissions>(PatientManagementPermissions.SurgeriesHistoryUpdate)]
        [HttpPut(Name = "UpdateSurgeriesHistoryAsync")]
        public async Task<ActionResult<ApiResponse<UpdateSurgeriesHistoryResponse>>> UpdateAsync([FromBody] UpdateSurgeriesHistoryRequest request)
        {
            UpdateSurgeriesHistoryResponse response = await _sender.Send(request);

            return CreateResponse(
                response,
                StatusCodes.Status200OK,
                "Surgeries History updated successfully!");
        }

        [HasPermission<PatientManagementPermissions>(PatientManagementPermissions.SurgeriesHistoryDelete)]
        [HttpDelete("{ID:int}", Name = "DeleteSurgeriesHistoryAsync")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteAsync([FromRoute] int ID)
        {
            DeleteSurgeriesHistoryRequest request = new()
            {
                Id = ID
            };

            var success = await _sender.Send(request);

            return CreateResponse(
                success,
                StatusCodes.Status200OK,
                "Surgeries History deleted successfully!");
        }
    }
}