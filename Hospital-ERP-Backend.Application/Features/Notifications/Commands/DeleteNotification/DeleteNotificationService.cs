using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Notifications.Commands.DeleteNotification
{
    internal class DeleteNotificationService
        : IRequestHandler<DeleteNotificationRequest, bool>
    {
        private readonly IValidator<DeleteNotificationRequest> _validator;
        private readonly IBaseCommandRepository<Notification> _repository;

        public DeleteNotificationService(
            IValidator<DeleteNotificationRequest> validator,
            IBaseCommandRepository<Notification> repository)
        {
            _validator = validator;
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteNotificationRequest request, CancellationToken cancellationToken)
        {
            return await DeleteNotificationAsync(request);
        }

        private async Task<bool> DeleteNotificationAsync(
            DeleteNotificationRequest request)
        {
            var validationResult =
                await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(
                    string.Join(", ",
                    validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            bool notification =
                await _repository.IsExistAsync(request.Id);

            if (!notification)
            {
                throw new KeyNotFoundException($"Notification with Id {request.Id} not found.");
            }

            bool isDeleted =
                await _repository.DeleteAsync(request.Id);

            if (!isDeleted)
            {
                throw new InvalidOperationException($"Failed to delete Notification with Id {request.Id}.");
            }

            return isDeleted;
        }
    }
}