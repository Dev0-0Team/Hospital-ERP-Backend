using Hospital_ERP_Backend.Application.Features.Appointments.Commands.CreateAppointment;
using Hospital_ERP_Backend.Application.Features.Appointments.Commands.DeleteAppointment;
using Hospital_ERP_Backend.Application.Features.Appointments.Commands.UpdateAppointment;
using Hospital_ERP_Backend.Application.Features.Appointments.Queries.GetAllAppointments;
using Hospital_ERP_Backend.Application.Features.Appointments.Queries.GetAppointment;
using Hospital_ERP_Backend.Application.Security.Authorization;
using Hospital_ERP_Backend.Domain.Enums.PermissionBits;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_ERP_Backend.API.Controllers
{

    [Route("api/Appointments")]
    [ApiController]
    [Authorize]
    public class AppointmentsController : BaseController
    {

        private readonly ISender _sender;

        public AppointmentsController(ISender sender)
        {
            _sender = sender;
        }

        [HasPermission<AppointmentAndQueuePermissions>(AppointmentAndQueuePermissions.AppointmentsRead)]
        [HttpGet(Name = "GetAllAppointmentsAsync")]
        public async Task<ActionResult<ApiResponse<IEnumerable<GetAllAppointmentsResponse>?>>> GetAllAsync([FromQuery] int page = 1)
        {

            GetAllAppointmentsRequest getAllAppointments = new GetAllAppointmentsRequest
            {
                Page = page
            };


            var list = await _sender.Send(getAllAppointments);


            return CreateResponse<IEnumerable<GetAllAppointmentsResponse>?>(list, StatusCodes.Status200OK, $"Row: {list.Count()}");
        }

        [HasPermission<AppointmentAndQueuePermissions>(AppointmentAndQueuePermissions.AppointmentsRead)]
        [HttpGet("{ID}", Name = "GetAppointmentByID")]
        public async Task<ActionResult<ApiResponse<GetAppointmentResponse?>>> GetByIDAsync([FromRoute] int ID)
        {
            GetAppointmentRequest getAppointmentRequest = new GetAppointmentRequest
            {
                Id = ID
            };


            var response = await _sender.Send(getAppointmentRequest);


            return CreateResponse<GetAppointmentResponse?>(response, StatusCodes.Status200OK, "Found Successfully!");
        }

        [HasPermission<AppointmentAndQueuePermissions>(AppointmentAndQueuePermissions.AppointmentsCreate)]
        [HttpPost(Name = "CreateAppointmentAsync")]
        public async Task<ActionResult<ApiResponse<CreateAppointmentResponse>>> CreateAsync([FromBody] CreateAppointmentRequest request)
        {
            var success = await _sender.Send(request);


            return CreatedAtRoute("GetAppointmentByID",
                new { ID = success!.Id },
                new ApiResponse<CreateAppointmentResponse>
                {
                    statusCode = StatusCodes.Status201Created,
                    Message = "Appointment Created Successfully!",
                    Data = success
                });
        }

        [HasPermission<AppointmentAndQueuePermissions>(AppointmentAndQueuePermissions.AppointmentsUpdate)]
        [HttpPut(Name = "UpdateAppointmentAsync")]
        public async Task<ActionResult<ApiResponse<UpdateAppointmentResponse>>> UpdateAsync([FromBody] UpdateAppointmentRequest request)
        {

            var response = await _sender.Send(request);

            return CreateResponse<UpdateAppointmentResponse>(response, StatusCodes.Status200OK, "Appointment Updated Successfully!");
        }

        [HasPermission<AppointmentAndQueuePermissions>(AppointmentAndQueuePermissions.AppointmentsDelete)]
        [HttpDelete("{ID}", Name = "DeleteAppointmentAsync")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteAsync([FromRoute] int ID)
        {

            DeleteAppointmentRequest deleteAppointmentRequest = new DeleteAppointmentRequest
            {
                Id = ID
            };

            var success = await _sender.Send(deleteAppointmentRequest);

            return CreateResponse<bool>(success, StatusCodes.Status200OK, "Appointment Deleted Successfully!");
        }
    }
}