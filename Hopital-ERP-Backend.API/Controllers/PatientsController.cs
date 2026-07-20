using Hospital_ERP_Backend.API;
using Hospital_ERP_Backend.API.Controllers;
using Hospital_ERP_Backend.Application.Features.Beds.Commands.CreateBed;
using Hospital_ERP_Backend.Application.Features.Beds.Commands.DeleteBed;
using Hospital_ERP_Backend.Application.Features.Beds.Commands.UpdateBed;
using Hospital_ERP_Backend.Application.Features.Beds.Queries.GetAllBeds;
using Hospital_ERP_Backend.Application.Features.Beds.Queries.GetBed;
using Hospital_ERP_Backend.Application.Features.Patients.Commands.CreatePatient;
using Hospital_ERP_Backend.Application.Features.Patients.Commands.DeletePatient;
using Hospital_ERP_Backend.Application.Features.Patients.Commands.UpdatePatient;
using Hospital_ERP_Backend.Application.Features.Patients.Queries.GetAllPatients;
using Hospital_ERP_Backend.Application.Features.Patients.Queries.GetPatient;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hopital_ERP_Backend.API.Controllers
{
    [Route("api/Patients")]
    [ApiController]
    public class PatientsController : BaseController
    {
        private readonly ISender _sender;

        public PatientsController(ISender sender)
        {
            _sender = sender;
        }

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

        [HttpPost(Name = "CreatePatientAsync")]
        public async Task<ActionResult<ApiResponse<CreatePatientResponse>>> CreateAsync([FromBody] CreatePatientRequest request)
        {
            var success = await _sender.Send(request);
            return CreatedAtRoute("GetPatientByID", new { ID = success!.Id }, success);
        }

        [HttpPut(Name = "UpdatePatientAsync")]
        public async Task<ActionResult<ApiResponse<UpdatePatientResponse>>> UpdateAsync([FromBody] UpdatePatientRequest request)
        {
            var response = await _sender.Send(request);
            return CreateResponse<UpdatePatientResponse>(response, StatusCodes.Status200OK, "Patient Updated Successfully!");
        }

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
