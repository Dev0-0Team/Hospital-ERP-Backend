using Hospital_ERP_Backend.Application.Features.Doctors.Commands.CreateDoctor;
using Hospital_ERP_Backend.Application.Features.Doctors.Commands.DeleteDoctor;
using Hospital_ERP_Backend.Application.Features.Doctors.Commands.UpdateDoctor;
using Hospital_ERP_Backend.Application.Features.Doctors.Queries.GetAllDoctors;
using Hospital_ERP_Backend.Application.Features.Doctors.Queries.GetDoctor;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_ERP_Backend.API.Controllers
{
    [Route("api/Doctors")]
    [ApiController]
    public class DoctorsController : BaseController
    {
        private readonly ISender _sender;

        public DoctorsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet(Name = "GetAllDoctorsAsync")]
        public async Task<ActionResult<ApiResponse<IEnumerable<GetAllDoctorsResponse>?>>> GetAllAsync(
            [FromQuery] int page = 1)
        {
            GetAllDoctorsRequest request = new()
            {
                Page = page
            };

            var doctors = await _sender.Send(request);

            return CreateResponse<IEnumerable<GetAllDoctorsResponse>?>(
                doctors,
                StatusCodes.Status200OK,
                $"Rows: {doctors.Count()}");
        }

        [HttpGet("{ID:int}", Name = "GetDoctorByIdAsync")]
        public async Task<ActionResult<ApiResponse<GetDoctorResponse?>>> GetByIdAsync(
            [FromRoute] int ID)
        {
            GetDoctorRequest request = new()
            {
                Id = ID
            };

            var doctor = await _sender.Send(request);

            return CreateResponse<GetDoctorResponse?>(
                doctor,
                StatusCodes.Status200OK,
                "Doctor found successfully!");
        }

        [HttpPost(Name = "CreateDoctorAsync")]
        public async Task<ActionResult<ApiResponse<CreateDoctorResponse>>> CreateAsync(
            [FromBody] CreateDoctorRequest request)
        {
            var result = await _sender.Send(request);

            return CreatedAtRoute(
                "GetDoctorByIdAsync",
                new
                {
                    ID = result.Id
                },
                result);
        }

        [HttpPut(Name = "UpdateDoctorAsync")]
        public async Task<ActionResult<ApiResponse<UpdateDoctorResponse>>> UpdateAsync(
            [FromBody] UpdateDoctorRequest request)
        {
            var result = await _sender.Send(request);

            return CreateResponse<UpdateDoctorResponse>(
                result,
                StatusCodes.Status200OK,
                "Doctor updated successfully!");
        }

        [HttpDelete("{ID:int}", Name = "DeleteDoctorAsync")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteAsync(
            [FromRoute] int ID)
        {
            DeleteDoctorRequest request = new()
            {
                Id = ID
            };

            var result = await _sender.Send(request);

            return CreateResponse<bool>(
                result,
                StatusCodes.Status200OK,
                "Doctor deleted successfully!");
        }
    }
}