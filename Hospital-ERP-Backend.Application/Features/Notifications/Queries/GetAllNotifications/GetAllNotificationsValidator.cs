using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Notifications.Queries.GetAllNotifications
{
    internal class GetAllNotificationsValidator
        : AbstractValidator<GetAllNotificationsRequest>
    {
        public GetAllNotificationsValidator()
        {
            RuleFor(x => x.Page)
                .GreaterThan(0)
                .WithMessage("Page number must be greater than 0.");
        }
    }
}