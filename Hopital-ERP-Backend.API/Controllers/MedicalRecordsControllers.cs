using Hospital_ERP_Backend.API;
using Hospital_ERP_Backend.API.Controllers;
using Hospital_ERP_Backend.Application.Features.MedicalRecords.Commands.CreateMedicalRecord;
using Hospital_ERP_Backend.Application.Features.MedicalRecords.Commands.DeleteMedicalRecord;
using Hospital_ERP_Backend.Application.Features.MedicalRecords.Commands.UpdateMedicalRecord;
using Hospital_ERP_Backend.Application.Features.MedicalRecords.Queries.GetAllMedicalRecords;
using Hospital_ERP_Backend.Application.Features.MedicalRecords.Queries.GetMedicalRecord;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hopital_ERP_Backend.API.Controllers
{
    [Route("api/MedicalRecords")]
    [ApiController]
    public class MedicalRecordsController : BaseController
    {
        private readonly ISender _sender;

        public MedicalRecordsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet(Name = "GetAllMedicalRecordsAsync")]
        public async Task<ActionResult<ApiResponse<IEnumerable<GetAllMedicalRecordsResponse>?>>> GetAllAsync([FromQuery] int page = 1)
        {
            GetAllMedicalRecordsRequest request = new()
            {
                Page = page
            };

            var list = await _sender.Send(request);

            return CreateResponse<IEnumerable<GetAllMedicalRecordsResponse>?>(
                list,
                StatusCodes.Status200OK,
                $"Rows: {list.Count()}");
        }

        [HttpGet("{ID:int}", Name = "GetMedicalRecordByIdAsync")]
        public async Task<ActionResult<ApiResponse<GetMedicalRecordResponse?>>> GetByIdAsync([FromRoute] int ID)
        {
            GetMedicalRecordRequest request = new()
            {
                Id = ID
            };

            var response = await _sender.Send(request);

            return CreateResponse<GetMedicalRecordResponse?>(
                response,
                StatusCodes.Status200OK,
                "Medical record found successfully!");
        }

        [HttpPost(Name = "CreateMedicalRecordAsync")]
        public async Task<ActionResult<ApiResponse<CreateMedicalRecordResponse>>> CreateAsync([FromBody] CreateMedicalRecordRequest request)
        {
            var response = await _sender.Send(request);

            return CreatedAtRoute(
                "GetMedicalRecordByIdAsync",
                new { ID = response.Id },
                response);
        }

        [HttpPut(Name = "UpdateMedicalRecordAsync")]
        public async Task<ActionResult<ApiResponse<UpdateMedicalRecordResponse>>> UpdateAsync([FromBody] UpdateMedicalRecordRequest request)
        {
            var response = await _sender.Send(request);

            return CreateResponse(
                response,
                StatusCodes.Status200OK,
                "Medical record updated successfully!");
        }

        [HttpDelete("{ID:int}", Name = "DeleteMedicalRecordAsync")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteAsync([FromRoute] int ID)
        {
            DeleteMedicalRecordRequest request = new()
            {
                Id = ID
            };

            var success = await _sender.Send(request);

            return CreateResponse(
                success,
                StatusCodes.Status200OK,
                "Medical record deleted successfully!");
        }
    }
}