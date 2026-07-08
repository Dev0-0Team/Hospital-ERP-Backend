using Hospital_ERP_Backend.Application.Features.LabTests.Commands.CreateLabTest;
using Hospital_ERP_Backend.Application.Features.LabTests.Commands.DeleteLabTest;
using Hospital_ERP_Backend.Application.Features.LabTests.Commands.UpdateLabTest;
using Hospital_ERP_Backend.Application.Features.LabTests.Queries.GetLabTest;
using Hospital_ERP_Backend.Application.Features.LapTests.Queries.GetAllLabTests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_ERP_Backend.API.Controllers
{
    [Route("api/LabTests")]
    [ApiController]
    public class LabTestsController : BaseController
    {
        private readonly ISender _sender;

        public LabTestsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet(Name = "GetAllLabTestsAsync")]
        public async Task<ActionResult<ApiResponse<IEnumerable<GetAllLabTestsResponse>?>>> GetAllAsync([FromQuery] int page = 1)
        {
            GetAllLabTestsRequest request =
                new GetAllLabTestsRequest()
                {
                    Page = page
                };

            var list = await _sender.Send(request);

            return CreateResponse<IEnumerable<GetAllLabTestsResponse>?>(
                list,
                StatusCodes.Status200OK,
                $"Rows: {list.Count()}");
        }

        [HttpGet("{ID:int}", Name = "GetLabTestByIdAsync")]
        public async Task<ActionResult<ApiResponse<GetLabTestResponse?>>> GetLabTestByIdAsync([FromRoute] int ID)
        {
            GetLabTestRequest request =
                new GetLabTestRequest()
                {
                    Id = ID
                };

            var labTest = await _sender.Send(request);

            return CreateResponse<GetLabTestResponse?>(
                labTest,
                StatusCodes.Status200OK,
                "Lab Test Found Successfully!");
        }

        [HttpPost(Name = "CreateLabTestAsync")]
        public async Task<ActionResult<ApiResponse<CreateLabTestResponse>>> CreateAsync([FromBody] CreateLabTestRequest request)
        {
            var success = await _sender.Send(request);

            return CreatedAtRoute(
                "GetLabTestByIdAsync",
                new
                {
                    ID = success.Id
                },
                success);
        }

        [HttpPut(Name = "UpdateLabTestAsync")]
        public async Task<ActionResult<ApiResponse<UpdateLabTestResponse>>> UpdateAsync([FromBody] UpdateLabTestRequest request)
        {
            var response = await _sender.Send(request);

            return CreateResponse<UpdateLabTestResponse>(
                response,
                StatusCodes.Status200OK,
                "Lab Test Updated Successfully!");
        }

        [HttpDelete("{ID}", Name = "DeleteLabTestAsync")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteAsync([FromRoute] int ID)
        {
            DeleteLabTestRequest request =
                new DeleteLabTestRequest()
                {
                    Id = ID
                };

            var success = await _sender.Send(request);

            return CreateResponse<bool>(
                success,
                StatusCodes.Status200OK,
                "Lab Test Deleted Successfully!");
        }
    }
}