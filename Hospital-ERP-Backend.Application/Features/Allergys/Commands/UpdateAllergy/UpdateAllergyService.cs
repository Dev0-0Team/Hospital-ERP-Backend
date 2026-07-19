
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;
using Hospital_ERP_Backend.Application.Extensions;
namespace Hospital_ERP_Backend.Application.Features.Allergys.Commands.UpdateAllergy
{
    public class UpdateAllergyService : IRequestHandler<UpdateAllergyRequest, UpdateAllergyResponse>
    {
        private readonly IBaseCommandRepository<Allergy> _allergyRepository;

        public UpdateAllergyService(IBaseCommandRepository<Allergy> allergyRepository)
        {
            _allergyRepository = allergyRepository;
        }

        public async Task<UpdateAllergyResponse> Handle(UpdateAllergyRequest request, CancellationToken cancellationToken)
        {

            return await Task.FromResult(request)
                .Map(req => new Allergy { PatientId = req.Id, AllergyName = req.AllergyName, Severity = req.Severity })
                .MapAsync(async allergy => await _allergyRepository.CreateAsync(allergy))
                .MapAsync(async result => new UpdateAllergyResponse { PatientId = result.PatientId, AllergyName = result.AllergyName, Severity = result.Severity });
        }
    }
}