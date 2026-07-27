using Azure;
using Hospital_ERP_Backend.Application.Features.RadiologyReports.Commands.CreateRadiologyReport;
using Hospital_ERP_Backend.Application.Features.RadiologyReports.Commands.DeleteRadiologyReport;
using Hospital_ERP_Backend.Application.Features.RadiologyReports.Commands.UpdateRadiologyReport;
using Hospital_ERP_Backend.Application.Features.RadiologyReports.Queries.GetAllRadiologyReports;
using Hospital_ERP_Backend.Application.Features.RadiologyReports.Queries.GetRadiologyReport;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_ERP_Backend.API.Controllers
{
    [Route("api/RadiologyReports")]
    [ApiController]
    public class RadiologyReportsController : BaseController
    {
        private readonly ISender _sender;

        public RadiologyReportsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<GetAllRadiologyReportsResponse>?>>> GetAllAsync([FromQuery] int page = 1)
        {
            var reports = await _sender.Send(new GetAllRadiologyReportsRequest
            {
                Page = page
            });

            return CreateResponse(
                reports,
                StatusCodes.Status200OK,
                $"Rows: {reports.Count()}");
        }

        [HttpGet("{ID:int}", Name = "GetRadiologyReportByIdAsync")]
        public async Task<ActionResult<ApiResponse<GetRadiologyReportResponse?>>> GetByIdAsync(int ID)
        {
            var report = await _sender.Send(new GetRadiologyReportRequest
            {
                Id = ID
            });

            return CreateResponse(
                report,
                StatusCodes.Status200OK,
                "Radiology Report found successfully.");
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<CreateRadiologyReportResponse>>> CreateAsync([FromBody] CreateRadiologyReportRequest request)
        {
            var result = await _sender.Send(request);

            return CreatedAtRoute(
                "GetRadiologyReportByIdAsync",
                new { ID = result.Id },
                new ApiResponse<CreateRadiologyReportResponse>
                {
                    statusCode = StatusCodes.Status201Created,
                    Message = "Radiology Report Created Successfully!",
                    Data = result
                });
        }

        [HttpPut]
        public async Task<ActionResult<ApiResponse<UpdateRadiologyReportResponse>>> UpdateAsync([FromBody] UpdateRadiologyReportRequest request)
        {
            var result = await _sender.Send(request);

            return CreateResponse(
                result,
                StatusCodes.Status200OK,
                "Radiology Report updated successfully.");
        }

        [HttpDelete("{ID:int}")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteAsync(int ID)
        {
            var result = await _sender.Send(
                new DeleteRadiologyReportRequest
                {
                    Id = ID
                });

            return CreateResponse(
                result,
                StatusCodes.Status200OK,
                "Radiology Report deleted successfully.");
        }
    }
}