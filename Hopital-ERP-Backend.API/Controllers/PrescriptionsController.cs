using Hospital_ERP_Backend.Application.Features.Prescriptions.Commands.CreatePrescription;
using Hospital_ERP_Backend.Application.Features.Prescriptions.Commands.DeletePrescription;
using Hospital_ERP_Backend.Application.Features.Prescriptions.Commands.UpdatePrescription;
using Hospital_ERP_Backend.Application.Features.Prescriptions.Queries.GetAllPrescriptions;
using Hospital_ERP_Backend.Application.Features.Prescriptions.Queries.GetPrescription;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_ERP_Backend.API.Controllers
{
    [Route("api/Prescriptions")]
    [ApiController]
    public class PrescriptionsController : BaseController
    {
        private readonly ISender _sender;

        public PrescriptionsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet(Name = "GetAllPrescriptionsAsync")]
        public async Task<ActionResult<ApiResponse<IEnumerable<GetAllPrescriptionsResponse>?>>> GetAllAsync([FromQuery] int page = 1)
        {
            GetAllPrescriptionsRequest request = new()
            {
                Page = page
            };

            var list = await _sender.Send(request);

            return CreateResponse<IEnumerable<GetAllPrescriptionsResponse>?>(
                list,
                StatusCodes.Status200OK,
                $"Rows: {list.Count()}");
        }

        [HttpGet("{ID:int}", Name = "GetPrescriptionByIdAsync")]
        public async Task<ActionResult<ApiResponse<GetPrescriptionResponse?>>> GetByIdAsync([FromRoute] int ID)
        {
            GetPrescriptionRequest request = new()
            {
                Id = ID
            };

            var prescription = await _sender.Send(request);

            return CreateResponse<GetPrescriptionResponse?>(
                prescription,
                StatusCodes.Status200OK,
                "Prescription found successfully!");
        }

        [HttpPost(Name = "CreatePrescriptionAsync")]
        public async Task<ActionResult<ApiResponse<CreatePrescriptionResponse>>> CreateAsync([FromBody] CreatePrescriptionRequest request)
        {
            var response = await _sender.Send(request);

            return CreatedAtRoute(
                "GetPrescriptionByIdAsync",
                new
                {
                    ID = response.Id
                },
                response);
        }

        [HttpPut(Name = "UpdatePrescriptionAsync")]
        public async Task<ActionResult<ApiResponse<UpdatePrescriptionResponse>>> UpdateAsync([FromBody] UpdatePrescriptionRequest request)
        {
            var response = await _sender.Send(request);

            return CreateResponse<UpdatePrescriptionResponse>(
                response,
                StatusCodes.Status200OK,
                "Prescription updated successfully!");
        }

        [HttpDelete("{ID:int}", Name = "DeletePrescriptionAsync")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteAsync([FromRoute] int ID)
        {
            DeletePrescriptionRequest request = new()
            {
                Id = ID
            };

            var success = await _sender.Send(request);

            return CreateResponse<bool>(
                success,
                StatusCodes.Status200OK,
                "Prescription deleted successfully!");
        }
    }
}