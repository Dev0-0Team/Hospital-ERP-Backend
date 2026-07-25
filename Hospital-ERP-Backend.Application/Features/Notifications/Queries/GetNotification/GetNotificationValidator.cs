using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Notifications.Queries.GetNotification
{
    public class GetNotificationValidator
        : AbstractValidator<GetNotificationRequest>
    {
        public GetNotificationValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Notification Id must be greater than 0.");
        }
    }
}