using Hospital_ERP_Backend.Application.Features.Patients.Commands.CreatePatient;
using Hospital_ERP_Backend.Application.Features.Patients.Commands.DeletePatient;
using Hospital_ERP_Backend.Application.Features.Patients.Commands.UpdatePatient;
using Hospital_ERP_Backend.Application.Features.Patients.Queries.GetAllPatients;
using Hospital_ERP_Backend.Application.Features.Patients.Queries.GetPatient;
using Hospital_ERP_Backend.Application.Security.Authorization;
using Hospital_ERP_Backend.Domain.Enums.PermissionBits;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_ERP_Backend.API.Controllers
{
    [Route("api/Patients")]
    [ApiController]
    [Authorize]
    public class PatientsController : BaseController
    {
        private readonly ISender _sender;

        public PatientsController(ISender sender)
        {
            _sender = sender;
        }

        [HasPermission<PatientManagementPermissions>(PatientManagementPermissions.PatientRead)]
        [HttpGet(Name = "GetAllPatientsAsync")]
        public async Task<ActionResult<ApiResponse<IEnumerable<GetAllPatientsResponse>?>>> GetAllAsync([FromQuery] int page = 1)
        {
            GetAllPatientsRequest newRequest = new GetAllPatientsRequest
            {
                Page = page
            };

            var list = await _sender.Send(newRequest);
            return CreateResponse<IEnumerable<GetAllPatientsResponse>?>(list, StatusCodes.Status200OK, $"Row: {list.Count()}");
        }

        [HasPermission<PatientManagementPermissions>(PatientManagementPermissions.PatientRead)]
        [HttpGet("{ID}", Name = "GetPatientByID")]
        public async Task<ActionResult<ApiResponse<GetPatientResponse?>>> GetByIDAsync([FromRoute] int ID)
        {
            GetPatientRequest newRequest = new GetPatientRequest
            {
                Id = ID
            };
            var response = await _sender.Send(newRequest);
            return CreateResponse<GetPatientResponse?>(response, StatusCodes.Status200OK, "Found Successfully!");
        }

        [HasPermission<PatientManagementPermissions>(PatientManagementPermissions.PatientCreate)]
        [HttpPost(Name = "CreatePatientAsync")]
        public async Task<ActionResult<ApiResponse<CreatePatientResponse>>> CreateAsync([FromBody] CreatePatientRequest request)
        {
            var success = await _sender.Send(request);
            return CreatedAtRoute("GetPatientByID", new { ID = success!.Id },
                new ApiResponse<CreatePatientResponse>
                {
                    statusCode = StatusCodes.Status201Created,
                    message = "Patient Created Successfully!",
                    data = success
                });
        }


        [HasPermission<PatientManagementPermissions>(PatientManagementPermissions.PatientUpdate)]
        [HttpPut(Name = "UpdatePatientAsync")]
        public async Task<ActionResult<ApiResponse<UpdatePatientResponse>>> UpdateAsync([FromBody] UpdatePatientRequest request)
        {
            var response = await _sender.Send(request);
            return CreateResponse<UpdatePatientResponse>(response, StatusCodes.Status200OK, "Patient Updated Successfully!");
        }


        [HasPermission<PatientManagementPermissions>(PatientManagementPermissions.PatientDelete)]
        [HttpDelete("{ID}", Name = "DeletePatientAsync")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteAsync([FromRoute] int ID)
        {
            DeletePatientRequest newRequest = new DeletePatientRequest
            {
                Id = ID
            };
            var success = await _sender.Send(newRequest);
            return CreateResponse<bool>(success, StatusCodes.Status200OK, "Patient Deleted Successfully!");
        }
    }
}
