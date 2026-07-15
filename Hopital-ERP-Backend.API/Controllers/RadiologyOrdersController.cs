using Hospital_ERP_Backend.Application.Features.RadiologyOrders.Commands.CreateRadiologyOrder;
using Hospital_ERP_Backend.Application.Features.RadiologyOrders.Commands.DeleteRadiologyOrder;
using Hospital_ERP_Backend.Application.Features.RadiologyOrders.Commands.UpdateRadiologyOrder;
using Hospital_ERP_Backend.Application.Features.RadiologyOrders.Queries.GetAllRadiologyOrders;
using Hospital_ERP_Backend.Application.Features.RadiologyOrders.Queries.GetRadiologyOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_ERP_Backend.API.Controllers
{
    [Route("api/RadiologyOrders")]
    [ApiController]
    public class RadiologyOrdersController : BaseController
    {
        private readonly ISender _sender;

        public RadiologyOrdersController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page = 1)
        {
            return Ok(await _sender.Send(
                new GetAllRadiologyOrdersRequest
                {
                    Page = page
                }));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _sender.Send(
                new GetRadiologyOrderRequest
                {
                    Id = id
                }));
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            CreateRadiologyOrderRequest request)
        {
            var result = await _sender.Send(request);

            return CreatedAtAction(
                nameof(GetById),
                new { id = result.Id },
                result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(
            UpdateRadiologyOrderRequest request)
        {
            return Ok(await _sender.Send(request));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _sender.Send(
                new DeleteRadiologyOrderRequest
                {
                    Id = id
                }));
        }
    }
}