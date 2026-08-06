using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Notifications.Queries.GetAllNotifications
{
    internal class GetAllNotificationsService
        : IRequestHandler<GetAllNotificationsRequest,
            IEnumerable<GetAllNotificationsResponse>>
    {
        private readonly IBaseQueryRepository<Notification> _repository;

        private readonly IValidator<GetAllNotificationsRequest> _validator;

        public GetAllNotificationsService(
            IBaseQueryRepository<Notification> repository,
            IValidator<GetAllNotificationsRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<IEnumerable<GetAllNotificationsResponse>> Handle(
            GetAllNotificationsRequest request,
            CancellationToken cancellationToken)
        {
            return await GetAllNotificationsAsync(request);
        }

        private async Task<IEnumerable<GetAllNotificationsResponse>>
            GetAllNotificationsAsync(
            GetAllNotificationsRequest request)
        {
            var validationResult =
                await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(
                    string.Join(", ",
                    validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            IEnumerable<Notification> notifications =
                await _repository.GetAllAsync(request.Page);

            if (notifications == null || !notifications.Any())
            {
                throw new KeyNotFoundException(
                    $"No notifications found on page {request.Page}.");
            }

            return notifications.Select(x =>
                new GetAllNotificationsResponse
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    Title = x.Title,
                    Body = x.Body,
                    IsRead = x.IsRead ?? false
                });
        }
    }
}