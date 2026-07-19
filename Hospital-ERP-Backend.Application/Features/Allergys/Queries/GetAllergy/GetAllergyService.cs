using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Hospital_ERP_Backend.Application.Features.Allergys.Queries.GetAllergy
{
    public class GetAllergyService : IRequestHandler<GetAllergyRequest, GetAllergyResponse>
    {
        private readonly IBaseQueryRepository<Domain.Entities.Allergy> _allergyQueryRepository;

        public GetAllergyService(IBaseQueryRepository<Domain.Entities.Allergy> allergyQueryRepository)
        {
            _allergyQueryRepository = allergyQueryRepository;
        }

        public async Task<GetAllergyResponse> Handle(GetAllergyRequest request, CancellationToken cancellationToken)
        {
            // 1. جلب العنصر المحدد بالـ Id من قاعدة البيانات عبر Dapper الموحد
            var allergy = await _allergyQueryRepository.GetAsync(request.Id);

            if (allergy == null) return null!;

            // 2. تحويل البيانات وإرجاعها في كائن الاستجابة
            return new GetAllergyResponse
            {
                ID = allergy.Id,
                PatientId = allergy.PatientId,
                AllergyName = allergy.AllergyName,
                Severity = allergy.Severity
            };
        }
    }
}