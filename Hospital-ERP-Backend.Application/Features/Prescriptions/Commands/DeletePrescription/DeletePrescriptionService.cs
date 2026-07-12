using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Prescriptions.Commands.DeletePrescription
{
    public class DeletePrescriptionService : IRequestHandler<DeletePrescriptionRequest, bool>
    {
        private readonly IBaseCommandRepository<Prescription> _repository;
        private readonly IBaseQueryRepository<Prescription> _queryRepository;
        private readonly IValidator<DeletePrescriptionRequest> _validator;

        public DeletePrescriptionService(IBaseCommandRepository<Prescription> repository, IBaseQueryRepository<Prescription> queryRepository,
            IValidator<DeletePrescriptionRequest> validator)
        {
            _repository = repository;
            _queryRepository = queryRepository;
            _validator = validator;
        }

        public async Task<bool> Handle(DeletePrescriptionRequest request, CancellationToken cancellationToken)
        {
            return await DeletePrescriptionAsync(request);
        }

        private async Task<bool> DeletePrescriptionAsync(DeletePrescriptionRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            Prescription? prescription = await _queryRepository.GetAsync(request.Id);

            if (prescription == null)
            {
                throw new KeyNotFoundException($"Prescription with Id {request.Id} not found.");
            }

            bool isDeleted = await _repository.DeleteAsync(prescription.Id);

            if (!isDeleted)
            {
                throw new InvalidOperationException($"Failed to delete prescription with Id {request.Id}.");
            }

            return isDeleted;
        }
    }
}