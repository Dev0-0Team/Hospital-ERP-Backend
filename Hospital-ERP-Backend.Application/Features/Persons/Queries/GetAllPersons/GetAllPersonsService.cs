using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;

namespace Hospital_ERP_Backend.Application.Features.Persons.Queries.GetAllPersons
{
    public class GetAllPersonsService
    {
        private readonly IValidator<GetAllPersonsRequest> _validator;
        private readonly IBaseQueryRepository<Person> _iPerson;
        public GetAllPersonsService(IValidator<GetAllPersonsRequest> validator, IBaseQueryRepository<Person> iPerson)
        {
            _validator = validator;
            _iPerson = iPerson;
        }

        public async Task<IEnumerable<GetAllPersonsResponse>> GetAllPersonsAsync(GetAllPersonsRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }
            var persons = await _iPerson.GetAllAsync(request.page);
            return persons.Select(p => new GetAllPersonsResponse
            {
                Id = p.Id,
                FullName = p.FullName,
                Dob = p.Dob,
                Gender = p.Gender,
                Phone = p.Phone,
                Address = p.Address
            });
        }
        

    }
}
