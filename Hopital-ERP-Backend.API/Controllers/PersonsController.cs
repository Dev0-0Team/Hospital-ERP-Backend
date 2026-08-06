using Azure;
using Hospital_ERP_Backend.Application.Features.Persons.Commands.CreatePerson;
using Hospital_ERP_Backend.Application.Features.Persons.Commands.DeletePerson;
using Hospital_ERP_Backend.Application.Features.Persons.Commands.UpdatePerson;
using Hospital_ERP_Backend.Application.Features.Persons.Queries.GetAllPersons;
using Hospital_ERP_Backend.Application.Features.Persons.Queries.GetPerson;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_ERP_Backend.API.Controllers
{
    [Route("api/Persons")]
    [ApiController]
    public class PersonsController : BaseController
    {
        private readonly ISender _sender;
        public PersonsController
            (ISender sender)
        {
            _sender = sender;
        }

        [HttpGet(Name = "GetAllPersonsAsync")]
        public async Task<ActionResult<ApiResponse<IEnumerable<GetAllPersonsResponse>?>>> GetAllAsync([FromQuery] int page = 1)
        {
            GetAllPersonsRequest getAllPersons = new GetAllPersonsRequest
            {
                page = page
            };

            var list = await _sender.Send(getAllPersons);
            return CreateResponse<IEnumerable<GetAllPersonsResponse>?>(list, StatusCodes.Status200OK, $"Row: {list.Count()}");
        }


        [HttpGet("{ID}", Name = "GetPersonByID")]
        public async Task<ActionResult<ApiResponse<GetPersonResponse?>>> GetByIDAsync([FromRoute] int ID)
        {
            GetPersonRequest getPersonRequest = new GetPersonRequest
            {
                Id = ID
            };
            var response = await _sender.Send(getPersonRequest);
            return CreateResponse<GetPersonResponse?>(response, StatusCodes.Status200OK, "Found Successfully!");
        }

        [HttpPost(Name = "CreatePersonAsync")]
        public async Task<ActionResult<ApiResponse<CreatePersonResponse>>> CreateAsync([FromBody] CreatePersonRequest request)
        {

            var success = await _sender.Send(request);
            return CreatedAtRoute("GetPersonByID", new { ID = success!.Id },
                new ApiResponse<CreatePersonResponse>
                {
                    statusCode = StatusCodes.Status201Created,
                    Message = "Person Created Successfully!",
                    Data = success
                });
        }

        [HttpPut(Name = "UpdatePersonAsync")]
        public async Task<ActionResult<ApiResponse<UpdatePersonResponse>>> UpdateAsync([FromBody] UpdatePersonRequest request)
        {
            var response = await _sender.Send(request);
            return CreateResponse<UpdatePersonResponse>(response, StatusCodes.Status200OK, "Person Updated Successfully!");
        }

        [HttpDelete("{ID}", Name = "DeletePersonAsync")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteAsync([FromRoute] int ID)
        {
            DeletePersonRequest deletePersonRequest = new DeletePersonRequest
            {
                Id = ID
            };
            var success = await _sender.Send(deletePersonRequest);
            return CreateResponse<bool>(success, StatusCodes.Status200OK, "Person Deleted Successfully!");
        }

    }
}
