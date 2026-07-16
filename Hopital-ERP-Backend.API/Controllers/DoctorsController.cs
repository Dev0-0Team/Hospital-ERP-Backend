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

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page = 1)
        {
            var result = await _sender.Send(
                new GetAllDoctorsRequest
                {
                    Page = page
                });

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _sender.Send(
                new GetDoctorRequest
                {
                    Id = id
                });

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDoctorRequest request)
        {
            var result = await _sender.Send(request);

            return CreatedAtAction(
                nameof(GetById),
                new { id = result.Id },
                result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateDoctorRequest request)
        {
            var result = await _sender.Send(request);

            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _sender.Send(
                new DeleteDoctorRequest
                {
                    Id = id
                });

            return Ok(result);
        }
    }
}