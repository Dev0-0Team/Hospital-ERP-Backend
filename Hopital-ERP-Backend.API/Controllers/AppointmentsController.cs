using Hospital_ERP_Backend.API;
using Hospital_ERP_Backend.API.Controllers;
using Hospital_ERP_Backend.Application.Features.Appointments.Commands.CreateAppointment;
using Hospital_ERP_Backend.Application.Features.Appointments.Commands.DeleteAppointment;
using Hospital_ERP_Backend.Application.Features.Appointments.Commands.UpdateAppointment;
using Hospital_ERP_Backend.Application.Features.Appointments.Queries.GetAllAppointments;
using Hospital_ERP_Backend.Application.Features.Appointments.Queries.GetAppointment;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hopital_ERP_Backend.API.Controllers
{
 
    [Route("api/Appointments")]
    [ApiController]
    public class AppointmentsController : BaseController
    {
       
        private readonly ISender _sender;

        public AppointmentsController(ISender sender)
        {
            _sender = sender;
        }


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

     
        [HttpPost(Name = "CreateAppointmentAsync")]
        public async Task<ActionResult<ApiResponse<CreateAppointmentResponse>>> CreateAsync([FromBody] CreateAppointmentRequest request)
        {
            var success = await _sender.Send(request);

           
            return CreatedAtRoute("GetAppointmentByID", new { ID = success!.Id }, success);
        }

        [HttpPut(Name = "UpdateAppointmentAsync")]
        public async Task<ActionResult<ApiResponse<UpdateAppointmentResponse>>> UpdateAsync([FromBody] UpdateAppointmentRequest request)
        {
         
            var response = await _sender.Send(request);

            return CreateResponse<UpdateAppointmentResponse>(response, StatusCodes.Status200OK, "Appointment Updated Successfully!");
        }

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