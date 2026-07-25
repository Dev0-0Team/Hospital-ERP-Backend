using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Notifications.Commands.CreateNotification
{
    public class CreateNotificationValidator
        : AbstractValidator<CreateNotificationRequest>
    {
        public CreateNotificationValidator()
        {
            RuleFor(x => x.UserId)
                .GreaterThan(0)
                .WithMessage("User Id must be greater than 0.");

            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Title is required.");

            RuleFor(x => x.Body)
                .NotEmpty()
                .WithMessage("Body is required.");
        }
    }
}