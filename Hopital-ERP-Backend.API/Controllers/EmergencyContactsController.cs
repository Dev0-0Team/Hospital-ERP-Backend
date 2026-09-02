using Hospital_ERP_Backend.Application.Features.EmergencyContacts.Commands.CreateEmergencyContact;
using Hospital_ERP_Backend.Application.Features.EmergencyContacts.Commands.DeleteEmergencyContact;
using Hospital_ERP_Backend.Application.Features.EmergencyContacts.Commands.UpdateEmergencyContact;
using Hospital_ERP_Backend.Application.Features.EmergencyContacts.Queries.GetAllEmergencyContacts;
using Hospital_ERP_Backend.Application.Features.EmergencyContacts.Queries.GetEmergencyContact;
using Hospital_ERP_Backend.Application.Security.Authorization;
using Hospital_ERP_Backend.Domain.Enums.PermissionBits;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_ERP_Backend.API.Controllers
{
    [Route("api/EmergencyContacts")]
    [ApiController]
    [Authorize]
    public class EmergencyContactsController : BaseController
    {
        private readonly ISender _sender;

        public EmergencyContactsController(ISender sender)
        {
            _sender = sender;
        }

        [HasPermission<PatientManagementPermissions>(PatientManagementPermissions.EmergencyContactsCreate)]
        [HttpGet(Name = "GetAllEmergencyContactsAsync")]
        public async Task<ActionResult<ApiResponse<IEnumerable<GetAllEmergencyContactsResponse>?>>> GetAllAsync([FromQuery] int page = 1)
        {
            GetAllEmergencyContactsRequest request =
                new GetAllEmergencyContactsRequest()
                {
                    Page = page
                };

            var list = await _sender.Send(request);

            return CreateResponse<IEnumerable<GetAllEmergencyContactsResponse>?>(
                list,
                StatusCodes.Status200OK,
                $"Rows: {list.Count()}");
        }

        [HasPermission<PatientManagementPermissions>(PatientManagementPermissions.EmergencyContactsRead)]
        [HttpGet("{ID:int}", Name = "GetEmergencyContactByIdAsync")]
        public async Task<ActionResult<ApiResponse<GetEmergencyContactResponse?>>> GetEmergencyContactByIdAsync([FromRoute] int ID)
        {
            GetEmergencyContactRequest request =
                new GetEmergencyContactRequest()
                {
                    Id = ID
                };

            var emergencyContact = await _sender.Send(request);

            return CreateResponse<GetEmergencyContactResponse?>(
                emergencyContact,
                StatusCodes.Status200OK,
                "Emergency Contact Found Successfully!");
        }

        [HasPermission<PatientManagementPermissions>(PatientManagementPermissions.EmergencyContactsCreate)]
        [HttpPost(Name = "CreateEmergencyContactAsync")]
        public async Task<ActionResult<ApiResponse<CreateEmergencyContactResponse>>> CreateAsync([FromBody] CreateEmergencyContactRequest request)
        {
            var success = await _sender.Send(request);

            return CreatedAtRoute(
                "GetEmergencyContactByIdAsync",
                new
                {
                    ID = success.Id
                },
                new ApiResponse<CreateEmergencyContactResponse>
                {
                    statusCode = StatusCodes.Status201Created,
                    message = "Emergency Contact Created Successfully!",
                    data = success
                });
        }

        [HasPermission<PatientManagementPermissions>(PatientManagementPermissions.EmergencyContactsUpdate)]
        [HttpPut(Name = "UpdateEmergencyContactAsync")]
        public async Task<ActionResult<ApiResponse<UpdateEmergencyContactResponse>>> UpdateAsync([FromBody] UpdateEmergencyContactRequest request)
        {
            var response = await _sender.Send(request);

            return CreateResponse<UpdateEmergencyContactResponse>(
                response,
                StatusCodes.Status200OK,
                "Emergency Contact Updated Successfully!");
        }

        [HasPermission<PatientManagementPermissions>(PatientManagementPermissions.EmergencyContactsDelete)]
        [HttpDelete("{ID}", Name = "DeleteEmergencyContactAsync")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteAsync([FromRoute] int ID)
        {
            DeleteEmergencyContactRequest request =
                new DeleteEmergencyContactRequest()
                {
                    Id = ID
                };

            var success = await _sender.Send(request);

            return CreateResponse<bool>(
                success,
                StatusCodes.Status200OK,
                "Emergency Contact Deleted Successfully!");
        }
    }
}