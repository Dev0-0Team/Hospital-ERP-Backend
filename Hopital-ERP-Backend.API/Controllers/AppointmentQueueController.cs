using Hospital_ERP_Backend.Application.Features.AppointmentQueues.Commands.CreateAppointmentQueue;
using Hospital_ERP_Backend.Application.Features.AppointmentQueues.Commands.DeleteAppointmentQueue;
using Hospital_ERP_Backend.Application.Features.AppointmentQueues.Commands.UpdateAppointmentQueue;
using Hospital_ERP_Backend.Application.Features.AppointmentQueues.Queries.GetAllAppointmentQueues;
using Hospital_ERP_Backend.Application.Features.AppointmentQueues.Queries.GetAppointmentQueue;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_ERP_Backend.API.Controllers
{
    [Route("api/AppointmentQueues")]
    [ApiController]
    public class AppointmentQueueController : BaseController
    {
        private readonly ISender _sender;

        public AppointmentQueueController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet(Name = "GetAllAppointmentQueuesAsync")]
        public async Task<ActionResult<ApiResponse<IEnumerable<GetAllAppointmentQueuesResponse>?>>> GetAllAsync([FromQuery] int page = 1)
        {
            GetAllAppointmentQueuesRequest request = new()
            {
                Page = page
            };

            var list = await _sender.Send(request);

            return CreateResponse<IEnumerable<GetAllAppointmentQueuesResponse>?>(
                list,
                StatusCodes.Status200OK,
                $"Rows: {list.Count()}");
        }

        [HttpGet("{ID:int}", Name = "GetAppointmentQueueByIdAsync")]
        public async Task<ActionResult<ApiResponse<GetAppointmentQueueResponse?>>> GetByIdAsync([FromRoute] int ID)
        {
            GetAppointmentQueueRequest request = new()
            {
                Id = ID
            };

            var appointmentQueue = await _sender.Send(request);

            return CreateResponse<GetAppointmentQueueResponse?>(
                appointmentQueue,
                StatusCodes.Status200OK,
                "AppointmentQueue found successfully!");
        }

        [HttpPost(Name = "CreateAppointmentQueueAsync")]
        public async Task<ActionResult<ApiResponse<CreateAppointmentQueueResponse>>> CreateAsync([FromBody] CreateAppointmentQueueRequest request)
        {
            var response = await _sender.Send(request);

            return CreatedAtRoute(
                "GetAppointmentQueueByIdAsync",
                new
                {
                    ID = response.Id
                },
                response);
        }

        [HttpPut(Name = "UpdateAppointmentQueueAsync")]
        public async Task<ActionResult<ApiResponse<UpdateAppointmentQueueResponse>>> UpdateAsync([FromBody] UpdateAppointmentQueueRequest request)
        {
            var response = await _sender.Send(request);

            return CreateResponse(
                response,
                StatusCodes.Status200OK,
                "AppointmentQueue updated successfully!");
        }

        [HttpDelete("{ID:int}", Name = "DeleteAppointmentQueueAsync")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteAsync([FromRoute] int ID)
        {
            DeleteAppointmentQueueRequest request = new()
            {
                Id = ID
            };

            var success = await _sender.Send(request);

            return CreateResponse(
                success,
                StatusCodes.Status200OK,
                "AppointmentQueue deleted successfully!");
        }
    }
}