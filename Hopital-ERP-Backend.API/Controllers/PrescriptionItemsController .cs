using Hospital_ERP_Backend.Application.Features.PrescriptionItems.Commands.CreatePrescriptionItem;
using Hospital_ERP_Backend.Application.Features.PrescriptionItems.Commands.DeletePrescriptionItem;
using Hospital_ERP_Backend.Application.Features.PrescriptionItems.Commands.UpdatePrescriptionItem;
using Hospital_ERP_Backend.Application.Features.PrescriptionItems.Queries.GetAllPrescriptionItems;
using Hospital_ERP_Backend.Application.Features.PrescriptionItems.Queries.GetPrescriptionItem;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_ERP_Backend.API.Controllers
{
    [Route("api/PrescriptionItems")]
    [ApiController]
    public class PrescriptionItemsController : BaseController
    {
        private readonly ISender _sender;

        public PrescriptionItemsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet(Name = "GetAllPrescriptionItemsAsync")]
        public async Task<ActionResult<ApiResponse<IEnumerable<GetAllPrescriptionItemsResponse>?>>> GetAllAsync([FromQuery] int page = 1)
        {
            GetAllPrescriptionItemsRequest request = new()
            {
                Page = page
            };

            var list = await _sender.Send(request);

            return CreateResponse<IEnumerable<GetAllPrescriptionItemsResponse>?>(
                list,
                StatusCodes.Status200OK,
                $"Rows: {list.Count()}");
        }

        [HttpGet("{ID:int}", Name = "GetPrescriptionItemByIdAsync")]
        public async Task<ActionResult<ApiResponse<GetPrescriptionItemResponse?>>> GetByIdAsync([FromRoute] int ID)
        {
            GetPrescriptionItemRequest request = new()
            {
                Id = ID
            };

            var item = await _sender.Send(request);

            return CreateResponse<GetPrescriptionItemResponse?>(
                item,
                StatusCodes.Status200OK,
                "Prescription Item found successfully!");
        }

        [HttpPost(Name = "CreatePrescriptionItemAsync")]
        public async Task<ActionResult<ApiResponse<CreatePrescriptionItemResponse>>> CreateAsync([FromBody] CreatePrescriptionItemRequest request)
        {
            var response = await _sender.Send(request);

            return CreatedAtRoute(
                "GetPrescriptionItemByIdAsync",
                new
                {
                    ID = response.Id
                },
                response);
        }

        [HttpPut(Name = "UpdatePrescriptionItemAsync")]
        public async Task<ActionResult<ApiResponse<UpdatePrescriptionItemResponse>>> UpdateAsync([FromBody] UpdatePrescriptionItemRequest request)
        {
            var response = await _sender.Send(request);

            return CreateResponse<UpdatePrescriptionItemResponse>(
                response,
                StatusCodes.Status200OK,
                "Prescription Item updated successfully!");
        }

        [HttpDelete("{ID:int}", Name = "DeletePrescriptionItemAsync")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteAsync([FromRoute] int ID)
        {
            DeletePrescriptionItemRequest request = new()
            {
                Id = ID
            };

            var success = await _sender.Send(request);

            return CreateResponse<bool>(
                success,
                StatusCodes.Status200OK,
                "Prescription Item deleted successfully!");
        }
    }
}