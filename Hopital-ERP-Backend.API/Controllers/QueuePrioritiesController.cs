using Azure;
using Hospital_ERP_Backend.Application.Features.QueuePriorities.Commands.CreateQueuePriority;
using Hospital_ERP_Backend.Application.Features.QueuePriorities.Commands.DeleteQueuePriority;
using Hospital_ERP_Backend.Application.Features.QueuePriorities.Commands.UpdateQueuePriority;
using Hospital_ERP_Backend.Application.Features.QueuePriorities.Queries.GetAllQueuePriorities;
using Hospital_ERP_Backend.Application.Features.QueuePriorities.Queries.GetQueuePriority;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_ERP_Backend.API.Controllers
{
    [Route("api/QueuePriorities")]
    [ApiController]
    public class QueuePrioritiesController : BaseController
    {
        private readonly ISender _sender;

        public QueuePrioritiesController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet(Name = "GetAllQueuePrioritiesAsync")]
        public async Task<ActionResult<ApiResponse<IEnumerable<GetAllQueuePrioritiesResponse>?>>> GetAllAsync([FromQuery] int page = 1)
        {
            GetAllQueuePrioritiesRequest getAllQueuePriorities = new GetAllQueuePrioritiesRequest
            {
                Page = page
            };

            var list = await _sender.Send(getAllQueuePriorities);
            return CreateResponse<IEnumerable<GetAllQueuePrioritiesResponse>?>(list, StatusCodes.Status200OK, $"Row: {list.Count()}");
        }

        [HttpGet("{ID}", Name = "GetQueuePriorityByID")]
        public async Task<ActionResult<ApiResponse<GetQueuePriorityResponse?>>> GetByIDAsync([FromRoute] int ID)
        {
            GetQueuePriorityRequest getQueuePriorityRequest = new GetQueuePriorityRequest
            {
                Id = ID
            };
            var response = await _sender.Send(getQueuePriorityRequest);
            return CreateResponse<GetQueuePriorityResponse?>(response, StatusCodes.Status200OK, "Found Successfully!");
        }

        [HttpPost(Name = "CreateQueuePriorityAsync")]
        public async Task<ActionResult<ApiResponse<CreateQueuePriorityResponse>>> CreateAsync([FromBody] CreateQueuePriorityRequest request)
        {
            var success = await _sender.Send(request);
            return CreatedAtRoute("GetQueuePriorityByID", new { ID = success!.Id },
                new ApiResponse<CreateQueuePriorityResponse>
                {
                    statusCode = StatusCodes.Status201Created,
                    Message = "bed Created Successfully!",
                    Data = success
                });
        }

        [HttpPut(Name = "UpdateQueuePriorityAsync")]
        public async Task<ActionResult<ApiResponse<UpdateQueuePriorityResponse>>> UpdateAsync([FromBody] UpdateQueuePriorityRequest request)
        {
            var response = await _sender.Send(request);
            return CreateResponse<UpdateQueuePriorityResponse>(response, StatusCodes.Status200OK, "Queue Priority Updated Successfully!");
        }

        [HttpDelete("{ID}", Name = "DeleteQueuePriorityAsync")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteAsync([FromRoute] int ID)
        {
            DeleteQueuePriorityRequest deleteQueuePriorityRequest = new DeleteQueuePriorityRequest
            {
                Id = ID
            };
            var success = await _sender.Send(deleteQueuePriorityRequest);
            return CreateResponse<bool>(success, StatusCodes.Status200OK, "Queue Priority Deleted Successfully!");
        }
    }
}