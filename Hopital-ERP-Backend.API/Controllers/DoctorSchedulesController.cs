using Azure;
using Hospital_ERP_Backend.Application.Features.DoctorSchedules.Commands.CreateDoctorSchedule;
using Hospital_ERP_Backend.Application.Features.DoctorSchedules.Commands.DeleteDoctorSchedule;
using Hospital_ERP_Backend.Application.Features.DoctorSchedules.Commands.UpdateDoctorSchedule;
using Hospital_ERP_Backend.Application.Features.DoctorSchedules.Queries.GetAllDoctorSchedules;
using Hospital_ERP_Backend.Application.Features.DoctorSchedules.Queries.GetDoctorSchedule;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_ERP_Backend.API.Controllers
{
    [Route("api/DoctorSchedules")]
    [ApiController]
    public class DoctorSchedulesController : BaseController
    {
        private readonly ISender _sender;

        public DoctorSchedulesController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet(Name = "GetAllDoctorSchedulesAsync")]
        public async Task<ActionResult<ApiResponse<IEnumerable<GetAllDoctorSchedulesResponse>?>>> GetAllAsync(
            [FromQuery] int page = 1)
        {
            var schedules =
                await _sender.Send(
                    new GetAllDoctorSchedulesRequest
                    {
                        Page = page
                    });

            return CreateResponse<IEnumerable<GetAllDoctorSchedulesResponse>?>(
                schedules,
                StatusCodes.Status200OK,
                $"Rows: {schedules.Count()}");
        }

        [HttpGet("{ID:int}", Name = "GetDoctorScheduleByIdAsync")]
        public async Task<ActionResult<ApiResponse<GetDoctorScheduleResponse?>>> GetByIdAsync(
            [FromRoute] int ID)
        {
            var schedule =
                await _sender.Send(
                    new GetDoctorScheduleRequest
                    {
                        Id = ID
                    });

            return CreateResponse<GetDoctorScheduleResponse?>(
                schedule,
                StatusCodes.Status200OK,
                "Doctor Schedule found successfully!");
        }

        [HttpPost(Name = "CreateDoctorScheduleAsync")]
        public async Task<ActionResult<ApiResponse<CreateDoctorScheduleResponse>>> CreateAsync(
            [FromBody] CreateDoctorScheduleRequest request)
        {
            var result =
                await _sender.Send(request);

            return CreatedAtRoute(
                "GetDoctorScheduleByIdAsync",
                new { ID = result.Id },
                new ApiResponse<CreateDoctorScheduleResponse>
                {
                    statusCode = StatusCodes.Status201Created,
                    Message = "Doctor Schedule Created Successfully!",
                    Data = result
                });
        }

        [HttpPut(Name = "UpdateDoctorScheduleAsync")]
        public async Task<ActionResult<ApiResponse<UpdateDoctorScheduleResponse>>> UpdateAsync(
            [FromBody] UpdateDoctorScheduleRequest request)
        {
            var result =
                await _sender.Send(request);

            return CreateResponse(
                result,
                StatusCodes.Status200OK,
                "Doctor Schedule updated successfully!");
        }

        [HttpDelete("{ID:int}", Name = "DeleteDoctorScheduleAsync")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteAsync(
            [FromRoute] int ID)
        {
            var result =
                await _sender.Send(
                    new DeleteDoctorScheduleRequest
                    {
                        Id = ID
                    });

            return CreateResponse(
                result,
                StatusCodes.Status200OK,
                "Doctor Schedule deleted successfully!");
        }
    }
}