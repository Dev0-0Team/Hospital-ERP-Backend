using Hospital_ERP_Backend.Application.Features.ChronicDiseases.Commands.CreateChronicDisease;
using Hospital_ERP_Backend.Application.Features.ChronicDiseases.Commands.DeleteChronicDisease;
using Hospital_ERP_Backend.Application.Features.ChronicDiseases.Commands.UpdateChronicDisease;
using Hospital_ERP_Backend.Application.Features.ChronicDiseases.Queries.GetAllChronicDiseases;
using Hospital_ERP_Backend.Application.Features.ChronicDiseases.Queries.GetChronicDisease;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_ERP_Backend.API.Controllers
{
    [Route("api/ChronicDiseases")]
    [ApiController]
    public class ChronicDiseasesController : BaseController
    {
        private readonly ISender _sender;

        public ChronicDiseasesController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet(Name = "GetAllChronicDiseasesAsync")]
        public async Task<ActionResult<ApiResponse<IEnumerable<GetAllChronicDiseasesResponse>?>>> GetAllAsync(
            [FromQuery] int page = 1)
        {
            var diseases = await _sender.Send(
                new GetAllChronicDiseasesRequest
                {
                    Page = page
                });

            return CreateResponse<IEnumerable<GetAllChronicDiseasesResponse>?>(
                diseases,
                StatusCodes.Status200OK,
                $"Rows: {diseases.Count()}");
        }

        [HttpGet("{ID:int}", Name = "GetChronicDiseaseByIdAsync")]
        public async Task<ActionResult<ApiResponse<GetChronicDiseaseResponse?>>> GetByIdAsync(
            [FromRoute] int ID)
        {
            var disease = await _sender.Send(
                new GetChronicDiseaseRequest
                {
                    Id = ID
                });

            return CreateResponse<GetChronicDiseaseResponse?>(
                disease,
                StatusCodes.Status200OK,
                "Chronic Disease found successfully!");
        }

        [HttpPost(Name = "CreateChronicDiseaseAsync")]
        public async Task<ActionResult<ApiResponse<CreateChronicDiseaseResponse>>> CreateAsync(
            [FromBody] CreateChronicDiseaseRequest request)
        {
            var result = await _sender.Send(request);

            return CreatedAtRoute(
                "GetChronicDiseaseByIdAsync",
                new
                {
                    ID = result.Id
                },
                result);
        }

        [HttpPut(Name = "UpdateChronicDiseaseAsync")]
        public async Task<ActionResult<ApiResponse<UpdateChronicDiseaseResponse>>> UpdateAsync(
            [FromBody] UpdateChronicDiseaseRequest request)
        {
            var result = await _sender.Send(request);

            return CreateResponse<UpdateChronicDiseaseResponse>(
                result,
                StatusCodes.Status200OK,
                "Chronic Disease updated successfully!");
        }

        [HttpDelete("{ID:int}", Name = "DeleteChronicDiseaseAsync")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteAsync(
            [FromRoute] int ID)
        {
            var result = await _sender.Send(
                new DeleteChronicDiseaseRequest
                {
                    Id = ID
                });

            return CreateResponse<bool>(
                result,
                StatusCodes.Status200OK,
                "Chronic Disease deleted successfully!");
        }
    }
}