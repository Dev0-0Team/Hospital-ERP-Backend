
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;
using Hospital_ERP_Backend.Application.Extensions;
namespace Hospital_ERP_Backend.Application.Features.Allergys.Commands.CreateAllergy
{
    public class CreateAllergyService : IRequestHandler<CreateAllergyRequest, CreateAllergyResponse>
    {
        private readonly IBaseCommandRepository<Allergy> _allergyRepository;

        public CreateAllergyService(IBaseCommandRepository<Allergy> allergyRepository)
        {
            _allergyRepository = allergyRepository;
        }

        public async Task<CreateAllergyResponse> Handle(CreateAllergyRequest request, CancellationToken cancellationToken)
        {

            return await Task.FromResult(request)
                .Map(req => new Allergy { PatientId = req.Id, AllergyName = req.AllergyName, Severity = req.Severity })
                .MapAsync(async allergy => await _allergyRepository.CreateAsync(allergy))
                .MapAsync(async result => new CreateAllergyResponse { Id = result.PatientId, AllergyName = result.AllergyName, Severity = result.Severity });
        }
    }
}