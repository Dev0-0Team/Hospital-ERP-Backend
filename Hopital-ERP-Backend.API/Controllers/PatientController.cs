using Hospital_ERP_Backend.API;
using Hospital_ERP_Backend.API.Controllers;
using Hospital_ERP_Backend.Application.Features.Patients.Command.GreatPatient;
using Hospital_ERP_Backend.Application.Features.Patients.Command.UpdatePatient;
using Hospital_ERP_Backend.Application.Features.Patients.Command.DeletePatient;
using Hospital_ERP_Backend.Application.Features.Patients.Queries.GetAllPatients;
using Hospital_ERP_Backend.Application.Features.Patients.Queries.GetIDPatient;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hopital_ERP_Backend.API.Controllers
{
    [Route("api/QueuePriorities")]
    [ApiController]
    public class PatientController : BaseController
    {
        private readonly ISender _sender;

        public PatientController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet(Name = "GetAllPatientAsync")]
        public async Task<ActionResult<ApiResponse<IEnumerable<GetAllPatientQuery>?>>> GetAllAsync([FromQuery] int Patient = 1)
        {
            GetAllPatient getAllPatient = new GetAllPatient
            {
                PersonId = Patient
            };

            var list = await _sender.Send(getAllPatient);
            return CreateResponse<IEnumerable<GetAllPatientQuery>?>(list, StatusCodes.Status200OK, $"Row: {list.Count()}");
        }

        [HttpGet("{ID}", Name = "GetIDPateintAsync")]
        public async Task<ActionResult<ApiResponse<GetIDPatientQuery?>>> GetByIDAsync([FromRoute] int Patient)
        {
            GetIDPatient getIdPatient = new GetIDPatient
            {
               PersonId=Patient
            };
            var response = await _sender.Send(getIdPatient);
            return CreateResponse<GetIDPatientQuery?>(response, StatusCodes.Status200OK, "Found Successfully!");
        }

        [HttpPost(Name = "CreatePatientAsync")]
        public async Task<ActionResult<ApiResponse<GreatPatientCommand>>> CreateAsync([FromBody] CreatePatient request)
        {
            var greatPatient = await _sender.Send(request);
            return CreatedAtRoute("GetIDPateintAsync", new { PatientId = greatPatient!.PersonId }, greatPatient);
        }

        [HttpPut(Name = "UpdatePatientAsync")]
        public async Task<ActionResult<ApiResponse<UpdatePatientCommand>>> UpdateAsync([FromBody] UpdatePatient request)
        {
            var varPatient = await _sender.Send(request);
            return CreateResponse<UpdatePatientCommand>(varPatient, StatusCodes.Status200OK, "Queue Patient Updated Successfully!");
        }

        [HttpDelete("{ID}", Name = "DeletePatientAsync")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteAsync([FromRoute] int Patient)
        {
            DeletePatient deletePatient = new DeletePatient
            {
                PersonId = Patient
            };
            var success = await _sender.Send(deletePatient);
            return CreateResponse<bool>(success, StatusCodes.Status200OK, "Queue Patient Deleted Successfully!");
        }
    }
}