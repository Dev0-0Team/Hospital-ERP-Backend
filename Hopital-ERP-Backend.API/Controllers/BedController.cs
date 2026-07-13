using Hospital_ERP_Backend.API;
using Hospital_ERP_Backend.API.Controllers;
using Hospital_ERP_Backend.Application.Features.Beds.Commands.CreateBed;
using Hospital_ERP_Backend.Application.Features.Beds.Commands.DeleteBed;
using Hospital_ERP_Backend.Application.Features.Beds.Commands.UpdateBed;
using Hospital_ERP_Backend.Application.Features.Beds.Queries.GetAllBeds;
using Hospital_ERP_Backend.Application.Features.Beds.Queries.GetBed;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hopital_ERP_Backend.API.Controllers
{
    [Route("api/Beds")]
    [ApiController]
    public class BedController : BaseController
    {
        private readonly ISender _sender;

        public BedController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet(Name = "GetAllBedsAsync")]
        public async Task<ActionResult<ApiResponse<IEnumerable<GetAllBedsResponse>?>>> GetAllAsync([FromQuery] int page = 1)
        {
            GetAllBedsRequest getAllBedsRequest = new GetAllBedsRequest
            {
                Page = page
            };

            var list = await _sender.Send(getAllBedsRequest);
            return CreateResponse<IEnumerable<GetAllBedsResponse>?>(list, StatusCodes.Status200OK, $"Row: {list.Count()}");
        }

        [HttpGet("{ID}", Name = "GetBedByID")]
        public async Task<ActionResult<ApiResponse<GetBedResponse?>>> GetByIDAsync([FromRoute] int ID)
        {
            GetBedRequest getBedRequest = new GetBedRequest
            {
                Id = ID
            };
            var response = await _sender.Send(getBedRequest);
            return CreateResponse<GetBedResponse?>(response, StatusCodes.Status200OK, "Found Successfully!");
        }

        [HttpPost(Name = "CreateBedAsync")]
        public async Task<ActionResult<ApiResponse<CreateBedResponse>>> CreateAsync([FromBody] CreateBedRequest request)
        {
            var success = await _sender.Send(request);
            return CreatedAtRoute("GetBedByID", new { ID = success!.Id }, success);
        }

        [HttpPut(Name = "UpdateBedAsync")]
        public async Task<ActionResult<ApiResponse<UpdateBedResponse>>> UpdateAsync([FromBody] UpdateBedRequest request)
        {
            var response = await _sender.Send(request);
            return CreateResponse<UpdateBedResponse>(response, StatusCodes.Status200OK, "Bed Updated Successfully!");
        }

        [HttpDelete("{ID}", Name = "DeleteBedAsync")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteAsync([FromRoute] int ID)
        {
            DeleteBedRequest deleteBedRequest = new DeleteBedRequest
            {
                Id = ID
            };
            var success = await _sender.Send(deleteBedRequest);
            return CreateResponse<bool>(success, StatusCodes.Status200OK, "Bed Deleted Successfully!");
        }
    }
}