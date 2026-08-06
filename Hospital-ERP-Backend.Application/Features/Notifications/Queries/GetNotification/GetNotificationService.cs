using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Notifications.Queries.GetNotification
{
    internal class GetNotificationService
        : IRequestHandler<GetNotificationRequest, GetNotificationResponse>
    {
        private readonly IBaseQueryRepository<Notification> _repository;

        private readonly IValidator<GetNotificationRequest> _validator;

        public GetNotificationService(
            IBaseQueryRepository<Notification> repository,
            IValidator<GetNotificationRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<GetNotificationResponse> Handle(
            GetNotificationRequest request,
            CancellationToken cancellationToken)
        {
            return await GetNotificationAsync(request);
        }

        private async Task<GetNotificationResponse> GetNotificationAsync(
            GetNotificationRequest request)
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
                await _repository.GetAsync(request.Id);

            if (notification == null)
            {
                throw new KeyNotFoundException(
                    $"Notification with Id {request.Id} not found.");
            }

            return new GetNotificationResponse
            {
                Id = notification.Id,
                UserId = notification.UserId,
                Title = notification.Title,
                Body = notification.Body,
                IsRead = notification.IsRead ?? false
            };
        }
    }
}