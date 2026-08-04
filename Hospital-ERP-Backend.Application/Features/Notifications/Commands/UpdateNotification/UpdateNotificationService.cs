using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Notifications.Commands.UpdateNotification
{
    internal class UpdateNotificationService
        : IRequestHandler<UpdateNotificationRequest, UpdateNotificationResponse>
    {
        private readonly IValidator<UpdateNotificationRequest> _validator;

        private readonly IBaseCommandRepository<Notification> _repository;

        private readonly IBaseCommandRepository<User> _userRepository;
        public UpdateNotificationService(
            IValidator<UpdateNotificationRequest> validator,
            IBaseCommandRepository<Notification> repository,
            IBaseCommandRepository<User> userRepository)
        {
            _repository = repository;
            _validator = validator;
            _userRepository = userRepository;
        }

        public async Task<UpdateNotificationResponse> Handle(UpdateNotificationRequest request, CancellationToken cancellationToken)
        {
            return await UpdateNotificationAsync(request);
        }

        private async Task<UpdateNotificationResponse> UpdateNotificationAsync(UpdateNotificationRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(
                    string.Join(", ",
                    validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            bool isUserExist = await _userRepository.IsExistAsync(request.UserId);
            if (!isUserExist)
            {
                throw new KeyNotFoundException($"User with Id {request.UserId} not found.");
            }
            
            Notification? notification = await _repository.FindAsync(request.Id);

            if (notification == null)
            {
                throw new KeyNotFoundException($"Notification with Id {request.Id} not found.");
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