using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Hospital_ERP_Backend.Application.Features.Allergys.Queries.GetAllAllergy
{
    public class GetAllAllergyService : IRequestHandler<GetAllAllergyRequest, IEnumerable<GetAllAllergyResponse>>
    {
        private readonly IBaseQueryRepository<Domain.Entities.Allergy> _allergyQueryRepository;

        public GetAllAllergyService(IBaseQueryRepository<Domain.Entities.Allergy> allergyQueryRepository)
        {
            _allergyQueryRepository = allergyQueryRepository;
        }

        public async Task<IEnumerable<GetAllAllergyResponse>> Handle(GetAllAllergyRequest request, CancellationToken cancellationToken)
        {
            // 1. جلب البيانات التصريحي والسريع جداً من قاعدة البيانات عبر Dapper
            var allergies = await _allergyQueryRepository.GetAllAsync(request.Id);

            // 2. تحويل القائمة وظيفياً وتصريحياً باستخدام LINQ في سطر واحد
            return allergies.Select(a => new GetAllAllergyResponse
            {
                
                PatientId = a.PatientId,
                AllergyName = a.AllergyName,
                Severity = a.Severity
            });
        }
    }
}