using Hospital_ERP_Backend.Application.Features.DrugInteractions.Commands.CreateDrugInteraction;
using Hospital_ERP_Backend.Application.Features.DrugInteractions.Commands.DeleteDrugInteraction;
using Hospital_ERP_Backend.Application.Features.DrugInteractions.Commands.UpdateDrugInteraction;
using Hospital_ERP_Backend.Application.Features.DrugInteractions.Queries.GetAllDrugInteractions;
using Hospital_ERP_Backend.Application.Features.DrugInteractions.Queries.GetDrugInteraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_ERP_Backend.API.Controllers
{
    [Route("api/DrugInteractions")]
    [ApiController]
    public class DrugInteractionsController : BaseController
    {
        private readonly ISender _sender;

        public DrugInteractionsController(ISender sender)
        {
            _sender = sender;
        }

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
                response);
        }

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