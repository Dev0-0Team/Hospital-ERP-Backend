using Hospital_ERP_Backend.API;
using Hospital_ERP_Backend.API.Controllers;
using Hospital_ERP_Backend.Application.Persons.Commands.CreatePerson;
using Hospital_ERP_Backend.Application.Persons.Commands.DeletePerson;
using Hospital_ERP_Backend.Application.Persons.Commands.UpdatePerson;
using Hospital_ERP_Backend.Application.Persons.Queries.GetAllPersons;
using Hospital_ERP_Backend.Application.Persons.Queries.GetPerson;
using Microsoft.AspNetCore.Mvc;

namespace Hopital_ERP_Backend.API.Controllers
{
    [Route("api/Persons")]
    [ApiController]
    public class PersonsController : BaseController
    {
        private readonly GetAllPersonsService _getAllPerson;
        private readonly GetPersonService _getPerson;
        private readonly CreatePersonService _createPerson;
        private readonly UpdatePersonService _updatePerson;
        private readonly DeletePersonService _deletePerson;

        public PersonsController
            (GetAllPersonsService getAllPerson, GetPersonService getPerson, CreatePersonService createPerson,
            UpdatePersonService updatePerson, DeletePersonService deletePerson)
        {
            _getAllPerson = getAllPerson;
            _getPerson = getPerson;
            _createPerson = createPerson;
            _updatePerson = updatePerson;
            _deletePerson = deletePerson;
        }

        [HttpGet(Name = "GetAllPersonsAsync")]
        public async Task<ActionResult<ApiResponse<IEnumerable<GetAllPersonsResponse>?>>> GetAllAsync([FromQuery] int page = 1)
        {
            GetAllPersonsRequest getAllPersons = new GetAllPersonsRequest
            {
                page = page
            };

            var list = await _getAllPerson.GetAllPersonsAsync(getAllPersons);
            return CreateResponse<IEnumerable<GetAllPersonsResponse>?>(list, StatusCodes.Status200OK, $"Row: {list.Count()}");
        }


        [HttpGet("{ID}", Name = "GetPersonByID")]
        public async Task<ActionResult<ApiResponse<GetPersonResponse?>>> GetByIDAsync([FromRoute] int ID)
        {
            GetPersonRequest getPersonRequest = new GetPersonRequest
            {
                Id = ID
            };
            var response = await _getPerson.GetPersonAsync(getPersonRequest);
            return CreateResponse<GetPersonResponse?>(response, StatusCodes.Status200OK, "Found Successfully!");
        }

        [HttpPost(Name = "CreatePersonAsync")]
        public async Task<ActionResult<ApiResponse<CreatePersonResponse>>> CreateAsync([FromBody] CreatePersonRequest request)
        {

            var success = await _createPerson.CreateAsync(request);
            return CreatedAtRoute("GetPersonByID", new { ID = success!.Id }, success);
        }

        [HttpPut(Name = "UpdatePersonAsync")]
        public async Task<ActionResult<ApiResponse<UpdatePersonResponse>>> UpdateAsync([FromBody] UpdatePersonRequest request)
        {
            var response = await _updatePerson.UpdatePersonAsync(request);
            return CreateResponse<UpdatePersonResponse>(response, StatusCodes.Status200OK, "Person Updated Successfully!");
        }

        [HttpDelete("{ID}", Name = "DeletePersonAsync")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteAsync([FromRoute] int ID)
        {
            DeletePersonRequest deletePersonRequest = new DeletePersonRequest
            {
                Id = ID
            };
            var success = await _deletePerson.DeletePersonAsync(deletePersonRequest);
            return CreateResponse<bool>(success, StatusCodes.Status200OK, "Person Deleted Successfully!");
        }

    }
}
