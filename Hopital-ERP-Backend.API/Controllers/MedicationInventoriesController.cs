using Hospital_ERP_Backend.Application.Features.MedicationInventories.Commands.CreateMedicationInventory;
using Hospital_ERP_Backend.Application.Features.MedicationInventories.Commands.DeleteMedicationInventory;
using Hospital_ERP_Backend.Application.Features.MedicationInventories.Commands.UpdateMedicationInventory;
using Hospital_ERP_Backend.Application.Features.MedicationInventories.Queries.GetAllMedicationInventories;
using Hospital_ERP_Backend.Application.Features.MedicationInventories.Queries.GetMedicationInventory;
using Hospital_ERP_Backend.Application.Security.Authorization;
using Hospital_ERP_Backend.Domain.Enums.PermissionBits;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_ERP_Backend.API.Controllers
{
    [Route("api/MedicationInventories")]
    [ApiController]
    [Authorize]
    public class MedicationInventoriesController : BaseController
    {
        private readonly ISender _sender;

        public MedicationInventoriesController(ISender sender)
        {
            _sender = sender;
        }

        [HasPermission<PharmacyPermissions>(PharmacyPermissions.MedicationInventoryRead)]
        [HttpGet(Name = "GetAllMedicationInventoriesAsync")]
        public async Task<ActionResult<ApiResponse<IEnumerable<GetAllMedicationInventoriesResponse>?>>> GetAllAsync([FromQuery] int page = 1)
        {
            GetAllMedicationInventoriesRequest request =
                new()
                {
                    Page = page
                };

            var list = await _sender.Send(request);

            return CreateResponse<IEnumerable<GetAllMedicationInventoriesResponse>?>(
                list,
                StatusCodes.Status200OK,
                $"Rows: {list.Count()}");
        }

        [HasPermission<PharmacyPermissions>(PharmacyPermissions.MedicationInventoryRead)]
        [HttpGet("{ID:int}", Name = "GetMedicationInventoryByIdAsync")]
        public async Task<ActionResult<ApiResponse<GetMedicationInventoryResponse?>>> GetByIdAsync([FromRoute] int ID)
        {
            GetMedicationInventoryRequest request =
                new()
                {
                    Id = ID
                };

            var inventory = await _sender.Send(request);

            return CreateResponse<GetMedicationInventoryResponse?>(
                inventory,
                StatusCodes.Status200OK,
                "Medication Inventory found successfully!");
        }

        [HasPermission<PharmacyPermissions>(PharmacyPermissions.MedicationInventoryCreate)]
        [HttpPost(Name = "CreateMedicationInventoryAsync")]
        public async Task<ActionResult<ApiResponse<CreateMedicationInventoryResponse>>>
            CreateAsync([FromBody] CreateMedicationInventoryRequest request)
        {
            var response = await _sender.Send(request);

            return CreatedAtRoute(
                "GetMedicationInventoryByIdAsync",
                new
                {
                    ID = response.Id
                },
                new ApiResponse<CreateMedicationInventoryResponse>
                {
                    statusCode = StatusCodes.Status201Created,
                    message = "Medication Inventroy Created Successfully!",
                    data = response
                });
        }

        [HasPermission<PharmacyPermissions>(PharmacyPermissions.MedicationInventoryUpdate)]
        [HttpPut(Name = "UpdateMedicationInventoryAsync")]
        public async Task<ActionResult<ApiResponse<UpdateMedicationInventoryResponse>>>
            UpdateAsync([FromBody] UpdateMedicationInventoryRequest request)
        {
            var response = await _sender.Send(request);

            return CreateResponse<UpdateMedicationInventoryResponse>(
                response,
                StatusCodes.Status200OK,
                "Medication Inventory updated successfully!");
        }


        [HasPermission<PharmacyPermissions>(PharmacyPermissions.MedicationInventoryDelete)]
        [HttpDelete("{ID:int}", Name = "DeleteMedicationInventoryAsync")]
        public async Task<ActionResult<ApiResponse<bool>>>
            DeleteAsync([FromRoute] int ID)
        {
            DeleteMedicationInventoryRequest request =
                new()
                {
                    Id = ID
                };

            var success = await _sender.Send(request);

            return CreateResponse<bool>(
                success,
                StatusCodes.Status200OK,
                "Medication Inventory deleted successfully!");
        }
    }
}