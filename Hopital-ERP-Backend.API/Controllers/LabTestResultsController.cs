using Hospital_ERP_Backend.Application.Features.LabTestResults.Commands.CreateLabTestResult;
using Hospital_ERP_Backend.Application.Features.LabTestResults.Commands.DeleteLabTestResult;
using Hospital_ERP_Backend.Application.Features.LabTestResults.Commands.UpdateLabTestResult;
using Hospital_ERP_Backend.Application.Features.LabTestResults.Queries.GetAllLabTestResults;
using Hospital_ERP_Backend.Application.Features.LabTestResults.Queries.GetLabTestResult;
using Hospital_ERP_Backend.Application.Security.Authorization;
using Hospital_ERP_Backend.Domain.Enums.PermissionBits;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_ERP_Backend.API.Controllers
{
    [Route("api/LabTestResults")]
    [ApiController]
    [Authorize]
    public class LabTestResultsController : BaseController
    {
        private readonly ISender _sender;

        public LabTestResultsController(ISender sender)
        {
            _sender = sender;
        }

        [HasPermission<MedicalRecordsPermissions>(MedicalRecordsPermissions.LabTestResultsRead)]
        [HttpGet(Name = "GetAllLabTestResultsAsync")]
        public async Task<ActionResult<ApiResponse<IEnumerable<GetAllLabTestResultsResponse>?>>> GetAllAsync(
            [FromQuery] int page = 1)
        {
            GetAllLabTestResultsRequest request = new()
            {
                Page = page
            };

            var results = await _sender.Send(request);

            return CreateResponse<IEnumerable<GetAllLabTestResultsResponse>?>(
                results,
                StatusCodes.Status200OK,
                $"Rows: {results.Count()}");
        }

        [HasPermission<MedicalRecordsPermissions>(MedicalRecordsPermissions.LabTestResultsRead)]
        [HttpGet("{ID:int}", Name = "GetLabTestResultByIdAsync")]
        public async Task<ActionResult<ApiResponse<GetLabTestResultResponse?>>> GetByIdAsync(
            [FromRoute] int ID)
        {
            GetLabTestResultRequest request = new()
            {
                Id = ID
            };

            var result = await _sender.Send(request);

            return CreateResponse<GetLabTestResultResponse?>(
                result,
                StatusCodes.Status200OK,
                "Lab Test Result found successfully!");
        }

        [HasPermission<MedicalRecordsPermissions>(MedicalRecordsPermissions.LabTestResultsCreate)]
        [HttpPost(Name = "CreateLabTestResultAsync")]
        public async Task<ActionResult<ApiResponse<CreateLabTestResultResponse>>> CreateAsync(
            [FromBody] CreateLabTestResultRequest request)
        {
            var response = await _sender.Send(request);

            return CreatedAtRoute(
                "GetLabTestResultByIdAsync",
                new
                {
                    ID = response.Id
                },
                new ApiResponse<CreateLabTestResultResponse>
                {
                    statusCode = StatusCodes.Status201Created,
                    message = "Lab Test Result Created Successfully!",
                    data = response
                });
        }

        [HasPermission<MedicalRecordsPermissions>(MedicalRecordsPermissions.LabTestResultsUpdate)]
        [HttpPut(Name = "UpdateLabTestResultAsync")]
        public async Task<ActionResult<ApiResponse<UpdateLabTestResultResponse>>> UpdateAsync(
            [FromBody] UpdateLabTestResultRequest request)
        {
            var response = await _sender.Send(request);

            return CreateResponse(
                response,
                StatusCodes.Status200OK,
                "Lab Test Result updated successfully!");
        }

        [HasPermission<MedicalRecordsPermissions>(MedicalRecordsPermissions.LabTestResultsDelete)]
        [HttpDelete("{ID:int}", Name = "DeleteLabTestResultAsync")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteAsync(
            [FromRoute] int ID)
        {
            DeleteLabTestResultRequest request = new()
            {
                Id = ID
            };

            var response = await _sender.Send(request);

            return CreateResponse(
                response,
                StatusCodes.Status200OK,
                "Lab Test Result deleted successfully!");
        }
    }
}