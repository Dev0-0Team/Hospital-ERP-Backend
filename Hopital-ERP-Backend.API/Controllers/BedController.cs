using Hospital_ERP_Backend.Application.Features.Beds.Commands.CreateBed;
using Hospital_ERP_Backend.Application.Features.Beds.Commands.DeleteBed;
using Hospital_ERP_Backend.Application.Features.Beds.Commands.UpdateBed;
using Hospital_ERP_Backend.Application.Features.Beds.Queries.GetAllBeds;
using Hospital_ERP_Backend.Application.Features.Beds.Queries.GetBed;
using Hospital_ERP_Backend.Application.Security.Authorization;
using Hospital_ERP_Backend.Domain.Enums.PermissionBits;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_ERP_Backend.API.Controllers
{
    [Route("api/Beds")]
    [ApiController]
    [Authorize]
    public class BedController : BaseController
    {
        private readonly ISender _sender;

        public BedController(ISender sender)
        {
            _sender = sender;
        }

        [HasPermission<HospitalFacilityPermissions>(HospitalFacilityPermissions.BedsRead)]
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

        [HasPermission<HospitalFacilityPermissions>(HospitalFacilityPermissions.BedsRead)]
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

        [HasPermission<HospitalFacilityPermissions>(HospitalFacilityPermissions.BedsCreate)]
        [HttpPost(Name = "CreateBedAsync")]
        public async Task<ActionResult<ApiResponse<CreateBedResponse>>> CreateAsync([FromBody] CreateBedRequest request)
        {
            var success = await _sender.Send(request);
            return CreatedAtRoute("GetBedByID",
                new { ID = success!.Id },
                new ApiResponse<CreateBedResponse>
                {
                    statusCode = StatusCodes.Status201Created,
                    Message = "Bed Created Successfully!",
                    Data = success
                });
        }

        [HasPermission<HospitalFacilityPermissions>(HospitalFacilityPermissions.BedsUpdate)]
        [HttpPut(Name = "UpdateBedAsync")]
        public async Task<ActionResult<ApiResponse<UpdateBedResponse>>> UpdateAsync([FromBody] UpdateBedRequest request)
        {
            var response = await _sender.Send(request);
            return CreateResponse<UpdateBedResponse>(response, StatusCodes.Status200OK, "Bed Updated Successfully!");
        }

        [HasPermission<HospitalFacilityPermissions>(HospitalFacilityPermissions.BedsDelete)]
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