using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Notifications.Commands.DeleteNotification
{
    internal class DeleteNotificationValidator
        : AbstractValidator<DeleteNotificationRequest>
    {
        public DeleteNotificationValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Notification Id must be greater than 0.");
        }
    }
}