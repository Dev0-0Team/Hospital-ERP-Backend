using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_ERP_Backend.Application.Features.Nurses.Commands.DeleteNurse
{
    public class DeleteNurseService : IRequestHandler<DeleteNurseRequest, bool>
    {
        private readonly IBaseCommandRepository<Nurse> _repository;
        private readonly IBaseQueryRepository<Nurse> _queryRepository;
        private readonly IValidator<DeleteNurseRequest> _validator;

        public DeleteNurseService(IBaseCommandRepository<Nurse> repository, IBaseQueryRepository<Nurse> queryRepository,IValidator<DeleteNurseRequest> validator)
        {
            _repository = repository;
            _validator = validator;
            _queryRepository = queryRepository; 
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

            Nurse? nurse = await _queryRepository.GetAsync(request.Id);

            if (nurse == null)
            {
                throw new KeyNotFoundException($"Nurse with Id {request.Id} not found.");
            }

            bool result = await _repository.DeleteAsync(nurse.Id);

            if (!result)
            {
                throw new InvalidOperationException("Failed to delete nurse.");
            }

            return result;
        }
    }
}
