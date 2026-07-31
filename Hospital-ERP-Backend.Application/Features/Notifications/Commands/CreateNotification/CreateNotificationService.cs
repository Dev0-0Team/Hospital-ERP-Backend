using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Notifications.Commands.CreateNotification
{
    internal class CreateNotificationService
        : IRequestHandler<CreateNotificationRequest,
            CreateNotificationResponse>
    {
        private readonly IBaseCommandRepository<Notification> _repository;

        private readonly IValidator<CreateNotificationRequest> _validator;

        public CreateNotificationService(
            IBaseCommandRepository<Notification> repository,
            IValidator<CreateNotificationRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<CreateNotificationResponse> Handle(
            CreateNotificationRequest request,
            CancellationToken cancellationToken)
        {
            return await CreateNotificationAsync(request);
        }

        private async Task<CreateNotificationResponse>
            CreateNotificationAsync(
            CreateNotificationRequest request)
        {
            var validationResult =
                await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(
                    string.Join(", ",
                    validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            Notification notification = new()
            {
                UserId = request.UserId,
                Title = request.Title,
                Body = request.Body,
                IsRead = request.IsRead
            };

            Notification? result =
                await _repository.CreateAsync(notification);

            if (result == null)
            {
                throw new InvalidOperationException(
                    "Failed to create Notification.");
            }

            return new CreateNotificationResponse
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