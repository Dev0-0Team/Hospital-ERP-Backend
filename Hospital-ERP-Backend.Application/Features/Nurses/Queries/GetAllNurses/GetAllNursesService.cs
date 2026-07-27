using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;


namespace Hospital_ERP_Backend.Application.Features.Nurses.Queries.GetAllNurses
{
    internal class GetAllNursesService : IRequestHandler<GetAllNursesRequest, IEnumerable<GetAllNursesResponse>>
    {
        private readonly IBaseQueryRepository<Nurse> _repository;
        private readonly IValidator<GetAllNursesRequest> _validator;
        public GetAllNursesService(IBaseQueryRepository<Nurse> repository,  IValidator<GetAllNursesRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }
        
        public async Task<IEnumerable<GetAllNursesResponse>> Handle(GetAllNursesRequest request, CancellationToken cancellationToken)
        {
            return await GetAllNursesAsync(request);
        }

        private async Task<IEnumerable<GetAllNursesResponse>> GetAllNursesAsync(GetAllNursesRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            var nurses = await _repository.GetAllAsync(request.Page);

            if (nurses == null || nurses.Count() == 0)
            {
                throw new KeyNotFoundException($"No nurses found on page {request.Page}");
            }

            return nurses.Select(x => new GetAllNursesResponse
            {
                Id = x.Id,
                PersonId = x.PersonId,
                DepartmentId = x.DepartmentId
            });
        }
    }
}
