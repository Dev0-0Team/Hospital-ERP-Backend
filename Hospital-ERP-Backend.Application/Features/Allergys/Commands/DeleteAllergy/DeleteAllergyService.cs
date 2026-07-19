using Hospital_ERP_Backend.Application.Features.Allergys.Commamds.DeleteAllergy;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Hospital_ERP_Backend.Application.Features.Allergys.Commands.DeleteAllergy
{
    public class DeleteAllergyService : IRequestHandler<DeleteAllergyRequest, bool>
    {
        private readonly IBaseCommandRepository<Domain.Entities.Allergy> _allergyRepository;

        public DeleteAllergyService(IBaseCommandRepository<Domain.Entities.Allergy> allergyRepository)
        {
            _allergyRepository = allergyRepository;
        }

        public async Task<bool> Handle(DeleteAllergyRequest request, CancellationToken cancellationToken)
        {
            
            return await _allergyRepository.DeleteAsync(request.Id);
        }
    }
}