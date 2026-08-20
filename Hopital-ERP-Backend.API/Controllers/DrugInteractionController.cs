using Hospital_ERP_Backend.Application.Features.DrugInteractions.Commands.CreateDrugInteraction;
using Hospital_ERP_Backend.Application.Features.DrugInteractions.Commands.DeleteDrugInteraction;
using Hospital_ERP_Backend.Application.Features.DrugInteractions.Commands.UpdateDrugInteraction;
using Hospital_ERP_Backend.Application.Features.DrugInteractions.Queries.GetAllDrugInteractions;
using Hospital_ERP_Backend.Application.Features.DrugInteractions.Queries.GetDrugInteraction;
using Hospital_ERP_Backend.Application.Security.Authorization;
using Hospital_ERP_Backend.Domain.Enums.PermissionBits;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_ERP_Backend.API.Controllers
{
    [Route("api/DrugInteractions")]
    [ApiController]
    [Authorize]
    public class DrugInteractionsController : BaseController
    {
        private readonly ISender _sender;

        public DrugInteractionsController(ISender sender)
        {
            _sender = sender;
        }

        [HasPermission<PharmacyPermissions>(PharmacyPermissions.DrugInteractionsRead)]
        [HttpGet(Name = "GetAllDrugInteractionsAsync")]
        public async Task<ActionResult<ApiResponse<IEnumerable<GetAllDrugInteractionsResponse>?>>>
        GetAllAsync([FromQuery] int page = 1)
        {
            GetAllDrugInteractionsRequest request = new()
            {
                Page = page
            };

            var list = await _sender.Send(request);

            return CreateResponse<IEnumerable<GetAllDrugInteractionsResponse>?>(
                list,
                StatusCodes.Status200OK,
                $"Rows: {list.Count()}");
        }

        [HasPermission<PharmacyPermissions>(PharmacyPermissions.DrugInteractionsRead)]
        [HttpGet("{ID:int}", Name = "GetDrugInteractionByIdAsync")]
        public async Task<ActionResult<ApiResponse<GetDrugInteractionResponse?>>> GetByIdAsync([FromRoute] int ID)
        {
            GetDrugInteractionRequest request = new()
            {
                Id = ID
            };

            var interaction = await _sender.Send(request);

            return CreateResponse<GetDrugInteractionResponse?>(
                interaction,
                StatusCodes.Status200OK,
                "Drug Interaction found successfully!");
        }

        [HasPermission<PharmacyPermissions>(PharmacyPermissions.DrugInteractionsCreate)]
        [HttpPost(Name = "CreateDrugInteractionAsync")]
        public async Task<ActionResult<ApiResponse<CreateDrugInteractionResponse>>>
            CreateAsync([FromBody] CreateDrugInteractionRequest request)
        {
            var response = await _sender.Send(request);

            return CreatedAtRoute(
                "GetDrugInteractionByIdAsync",
                new
                {
                    ID = response.Id
                },
                new ApiResponse<CreateDrugInteractionResponse>
                {
                    statusCode = StatusCodes.Status201Created,
                    Message = "Drug Interaction Created Successfully!",
                    Data = response
                });
        }

        [HasPermission<PharmacyPermissions>(PharmacyPermissions.DrugInteractionsUpdate)]
        [HttpPut(Name = "UpdateDrugInteractionAsync")]
        public async Task<ActionResult<ApiResponse<UpdateDrugInteractionResponse>>>
            UpdateAsync([FromBody] UpdateDrugInteractionRequest request)
        {
            var response = await _sender.Send(request);

            return CreateResponse(
                response,
                StatusCodes.Status200OK,
                "Drug Interaction updated successfully!");
        }

        [HasPermission<PharmacyPermissions>(PharmacyPermissions.DrugInteractionsDelete)]
        [HttpDelete("{ID:int}", Name = "DeleteDrugInteractionAsync")]
        public async Task<ActionResult<ApiResponse<bool>>>
            DeleteAsync([FromRoute] int ID)
        {
            DeleteDrugInteractionRequest request = new()
            {
                Id = ID
            };

            var success = await _sender.Send(request);

            return CreateResponse(
                success,
                StatusCodes.Status200OK,
                "Drug Interaction deleted successfully!");
        }
    }
}