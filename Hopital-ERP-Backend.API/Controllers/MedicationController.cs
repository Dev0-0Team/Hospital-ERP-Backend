using Hospital_ERP_Backend.Application.Features.Medications.Commands.CreateMedication;
using Hospital_ERP_Backend.Application.Features.Medications.Commands.DeleteMedication;
using Hospital_ERP_Backend.Application.Features.Medications.Commands.UpdateMedication;
using Hospital_ERP_Backend.Application.Features.Medications.Queries.GetAllMedications;
using Hospital_ERP_Backend.Application.Features.Medications.Queries.GetMedicationById;
using Hospital_ERP_Backend.Application.Security.Authorization;
using Hospital_ERP_Backend.Domain.Enums.PermissionBits;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_ERP_Backend.API.Controllers
{
    [Route("api/Medications")]
    [ApiController]
    [Authorize]
    public class MedicationsController : BaseController
    {
        private readonly ISender _sender;

        public MedicationsController(ISender sender)
        {
            _sender = sender;
        }

        [HasPermission<PharmacyPermissions>(PharmacyPermissions.MedicationsRead)]
        [HttpGet(Name = "GetAllMedicationsAsync")]
        public async Task<ActionResult<ApiResponse<IEnumerable<GetAllMedicationsResponse>?>>> GetAllAsync([FromQuery] int page = 1)
        {
            GetAllMedicationsRequest request =
                new GetAllMedicationsRequest()
                {
                    Page = page
                };

            var list = await _sender.Send(request);

            return CreateResponse<IEnumerable<GetAllMedicationsResponse>?>(
                list,
                StatusCodes.Status200OK,
                $"Rows: {list.Count()}");
        }


        [HasPermission<PharmacyPermissions>(PharmacyPermissions.MedicationsRead)]
        [HttpGet("{ID:int}", Name = "GetMedicationByIdAsync")]
        public async Task<ActionResult<ApiResponse<GetMedicationResponse?>>> GetMedicationByIdAsync([FromRoute] int ID)
        {
            GetMedicationRequest request = new GetMedicationRequest()
            {
                Id = ID
            };
            var medication = await _sender.Send(request);

            return CreateResponse<GetMedicationResponse?>(medication, StatusCodes.Status200OK, "Medication found Successfully!");
        }


        [HasPermission<PharmacyPermissions>(PharmacyPermissions.MedicationsCreate)]
        [HttpPost(Name = "CreateMedicationAsync")]
        public async Task<ActionResult<ApiResponse<CreateMedicationResponse>>> CreateAsync([FromBody] CreateMedicationRequest request)
        {
            var success = await _sender.Send(request);

            return CreatedAtRoute("GetMedicationByIdAsync",
                new
                {
                    ID = success.Id
                },
                new ApiResponse<CreateMedicationResponse>
                {
                    statusCode = StatusCodes.Status201Created,
                    message = "Medication Created Successfully!",
                    data = success
                });
        }


        [HasPermission<PharmacyPermissions>(PharmacyPermissions.MedicationsUpdate)]
        [HttpPut(Name = "UpdateMedicationAsync")]
        public async Task<ActionResult<ApiResponse<UpdateMedicationResponse>>> UpdateAsync([FromBody] UpdateMedicationRequest request)
        {
            var response = await _sender.Send(request);

            return CreateResponse<UpdateMedicationResponse>(
                response,
                StatusCodes.Status200OK,
                "Medication Updated Successfully!");
        }


        [HasPermission<PharmacyPermissions>(PharmacyPermissions.MedicationsDelete)]
        [HttpDelete("{ID}", Name = "DeleteMedicationAsync")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteAsync([FromRoute] int ID)
        {
            DeleteMedicationRequest request =
                new DeleteMedicationRequest()
                {
                    Id = ID
                };

            var success = await _sender.Send(request);

            return CreateResponse<bool>(
                success,
                StatusCodes.Status200OK,
                "Medication Deleted Successfully!");
        }
    }
}