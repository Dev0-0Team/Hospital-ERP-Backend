using Hospital_ERP_Backend.Application.Features.LabOrders.Commands.CreateLabOrder;
using Hospital_ERP_Backend.Application.Features.LabOrders.Commands.DeleteLabOrder;
using Hospital_ERP_Backend.Application.Features.LabOrders.Commands.UpdateLabOrder;
using Hospital_ERP_Backend.Application.Features.LabOrders.Queries.GetAllLabOrders;
using Hospital_ERP_Backend.Application.Features.LabOrders.Queries.GetLabOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_ERP_Backend.API.Controllers
{
    [Route("api/LabOrders")]
    [ApiController]
    public class LabOrdersController : BaseController
    {
        private readonly ISender _sender;

        public LabOrdersController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet(Name = "GetAllLabOrdersAsync")]
        public async Task<ActionResult<ApiResponse<IEnumerable<GetAllLabOrdersResponse>?>>> GetAllAsync(
            [FromQuery] int page = 1)
        {
            GetAllLabOrdersRequest request = new()
            {
                Page = page
            };

            var labOrders = await _sender.Send(request);

            return CreateResponse<IEnumerable<GetAllLabOrdersResponse>?>(
                labOrders,
                StatusCodes.Status200OK,
                $"Rows: {labOrders.Count()}");
        }

        [HttpGet("{ID:int}", Name = "GetLabOrderByIdAsync")]
        public async Task<ActionResult<ApiResponse<GetLabOrderResponse?>>> GetByIdAsync(
            [FromRoute] int ID)
        {
            GetLabOrderRequest request = new()
            {
                Id = ID
            };

            var labOrder = await _sender.Send(request);

            return CreateResponse<GetLabOrderResponse?>(
                labOrder,
                StatusCodes.Status200OK,
                "Lab Order found successfully!");
        }

        [HttpPost(Name = "CreateLabOrderAsync")]
        public async Task<ActionResult<ApiResponse<CreateLabOrderResponse>>> CreateAsync(
            [FromBody] CreateLabOrderRequest request)
        {
            var result = await _sender.Send(request);

            return CreatedAtRoute(
                "GetLabOrderByIdAsync",
                new
                {
                    ID = result.Id
                },
                result);
        }

        [HttpPut(Name = "UpdateLabOrderAsync")]
        public async Task<ActionResult<ApiResponse<UpdateLabOrderResponse>>> UpdateAsync(
            [FromBody] UpdateLabOrderRequest request)
        {
            var result = await _sender.Send(request);

            return CreateResponse<UpdateLabOrderResponse>(
                result,
                StatusCodes.Status200OK,
                "Lab Order updated successfully!");
        }

        [HttpDelete("{ID:int}", Name = "DeleteLabOrderAsync")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteAsync(
            [FromRoute] int ID)
        {
            DeleteLabOrderRequest request = new()
            {
                Id = ID
            };

            var result = await _sender.Send(request);

            return CreateResponse<bool>(
                result,
                StatusCodes.Status200OK,
                "Lab Order deleted successfully!");
        }
    }
}