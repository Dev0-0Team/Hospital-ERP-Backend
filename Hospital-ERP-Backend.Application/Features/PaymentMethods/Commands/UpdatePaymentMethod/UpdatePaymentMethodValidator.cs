using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.PaymentMethods.Commands.UpdatePaymentMethod
{
    public class UpdatePaymentMethodValidator : AbstractValidator<UpdatePaymentMethodRequest>
    {
        public UpdatePaymentMethodValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Payment method Id must be greater than 0.");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Payment method name is required.")
                .MaximumLength(50).WithMessage("Payment method name must not exceed 50 characters.");
        }
    }
}
