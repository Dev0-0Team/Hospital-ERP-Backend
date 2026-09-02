using Hospital_ERP_Backend.Application.Features.Allergies.Commands.CreateAllergy;
using Hospital_ERP_Backend.Application.Features.Allergies.Commands.DeleteAllergy;
using Hospital_ERP_Backend.Application.Features.Allergies.Commands.UpdateAllergy;
using Hospital_ERP_Backend.Application.Features.Allergies.Queries.GetAllAllergies;
using Hospital_ERP_Backend.Application.Features.Allergies.Queries.GetAllergy;
using Hospital_ERP_Backend.Application.Security.Authorization;
using Hospital_ERP_Backend.Domain.Enums.PermissionBits;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_ERP_Backend.API.Controllers
{
    [Route("api/Allergies")]
    [ApiController]
    [Authorize]
    public class AllergiesController : BaseController
    {
        private readonly ISender _sender;

        public AllergiesController(ISender sender)
        {
            _sender = sender;
        }


        [HasPermission<PatientManagementPermissions>(PatientManagementPermissions.AllergiesRead)]
        [HttpGet(Name = "GetAllAllergiesAsync")]
        public async Task<ActionResult<ApiResponse<IEnumerable<GetAllAllergiesResponse>?>>> GetAllAsync(
            [FromQuery] int page = 1)
        {
            GetAllAllergiesRequest request = new()
            {
                Page = page
            };

            var list = await _sender.Send(request);

            return CreateResponse<IEnumerable<GetAllAllergiesResponse>?>(
                list,
                StatusCodes.Status200OK,
                $"Rows: {list.Count()}");
        }


        [HasPermission<PatientManagementPermissions>(PatientManagementPermissions.AllergiesRead)]
        [HttpGet("{ID:int}", Name = "GetAllergyByIdAsync")]
        public async Task<ActionResult<ApiResponse<GetAllergyResponse?>>>
            GetByIdAsync([FromRoute] int ID)
        {
            GetAllergyRequest request = new()
            {
                Id = ID
            };

            var allergy = await _sender.Send(request);

            return CreateResponse<GetAllergyResponse?>(
                allergy,
                StatusCodes.Status200OK,
                "Allergy found successfully!");
        }

        [HasPermission<PatientManagementPermissions>(PatientManagementPermissions.AllergiesCreate)]
        [HttpPost(Name = "CreateAllergyAsync")]
        public async Task<ActionResult<ApiResponse<CreateAllergyResponse>>>
            CreateAsync([FromBody] CreateAllergyRequest request)
        {
            CreateAllergyResponse response =
                await _sender.Send(request);

            return CreatedAtRoute(
                "GetAllergyByIdAsync",
                new
                {
                    ID = response.Id
                },
                new ApiResponse<CreateAllergyResponse>
                {
                    statusCode = StatusCodes.Status201Created,
                    message = "Allergy Created Successfully!",
                    data = response
                });
        }

        [HasPermission<PatientManagementPermissions>(PatientManagementPermissions.AllergiesUpdate)]
        [HttpPut(Name = "UpdateAllergyAsync")]
        public async Task<ActionResult<ApiResponse<UpdateAllergyResponse>>>
            UpdateAsync([FromBody] UpdateAllergyRequest request)
        {
            UpdateAllergyResponse response =
                await _sender.Send(request);

            return CreateResponse(
                response,
                StatusCodes.Status200OK,
                "Allergy Updated Successfully!");
        }

        [HasPermission<PatientManagementPermissions>(PatientManagementPermissions.AllergiesDelete)]
        [HttpDelete("{ID:int}", Name = "DeleteAllergyAsync")]
        public async Task<ActionResult<ApiResponse<bool>>>
            DeleteAsync([FromRoute] int ID)
        {
            DeleteAllergyRequest request = new()
            {
                Id = ID
            };

            bool success =
                await _sender.Send(request);

            return CreateResponse(
                success,
                StatusCodes.Status200OK,
                "Allergy Deleted Successfully!");
        }
    }
}