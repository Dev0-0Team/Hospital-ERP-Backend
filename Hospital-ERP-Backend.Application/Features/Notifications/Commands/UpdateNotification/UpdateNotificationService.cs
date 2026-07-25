using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Notifications.Commands.UpdateNotification
{
    public class UpdateNotificationService
        : IRequestHandler<UpdateNotificationRequest, UpdateNotificationResponse>
    {
        private readonly IValidator<UpdateNotificationRequest> _validator;

        private readonly IBaseCommandRepository<Notification> _repository;

        private readonly IBaseQueryRepository<Notification> _queryRepository;

        public UpdateNotificationService(
            IValidator<UpdateNotificationRequest> validator,
            IBaseCommandRepository<Notification> repository,
            IBaseQueryRepository<Notification> queryRepository)
        {
            _validator = validator;
            _repository = repository;
            _queryRepository = queryRepository;
        }

        public async Task<UpdateNotificationResponse> Handle(
            UpdateNotificationRequest request,
            CancellationToken cancellationToken)
        {
            return await UpdateNotificationAsync(request);
        }

        private async Task<UpdateNotificationResponse> UpdateNotificationAsync(
            UpdateNotificationRequest request)
        {
            var validationResult =
                await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(
                    string.Join(", ",
                    validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            Notification? notification =
                await _queryRepository.GetAsync(request.Id);

            if (notification == null)
            {
                throw new KeyNotFoundException(
                    $"Notification with Id {request.Id} not found.");
            }

            notification.UserId = request.UserId;
            notification.Title = request.Title;
            notification.Body = request.Body;
            notification.IsRead = request.IsRead;
            notification.UpdatedAt = DateTime.UtcNow;

            Notification? result =
                await _repository.UpdateAsync(notification);

            if (result == null)
            {
                throw new InvalidOperationException(
                    "Failed to update Notification.");
            }

            return new UpdateNotificationResponse
            {
                Id = result.Id,
                UserId = result.UserId,
                Title = result.Title,
                Body = result.Body,
                IsRead = result.IsRead ?? false
            };
        }
    }
}