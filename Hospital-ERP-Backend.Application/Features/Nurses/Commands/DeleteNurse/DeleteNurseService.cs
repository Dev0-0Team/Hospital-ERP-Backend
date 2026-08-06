using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;


namespace Hospital_ERP_Backend.Application.Features.Nurses.Commands.DeleteNurse
{
    internal class DeleteNurseService : IRequestHandler<DeleteNurseRequest, bool>
    {
        private readonly IBaseCommandRepository<Nurse> _repository;
        private readonly IValidator<DeleteNurseRequest> _validator;

        public DeleteNurseService(IBaseCommandRepository<Nurse> repository,IValidator<DeleteNurseRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<bool> Handle(DeleteNurseRequest request,  CancellationToken cancellationToken)
        {
            return await DeleteNurseAsync(request);
        }

        private async Task<bool> DeleteNurseAsync(DeleteNurseRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            bool nurse = await _repository.IsExistAsync(request.Id);

            if (!nurse)
            {
                throw new KeyNotFoundException($"Nurse with Id {request.Id} not found.");
            }

            bool result = await _repository.DeleteAsync(request.Id);

            if (!result)
            {
                throw new InvalidOperationException("Failed to delete nurse.");
            }

            return result;
        }
    }
}
