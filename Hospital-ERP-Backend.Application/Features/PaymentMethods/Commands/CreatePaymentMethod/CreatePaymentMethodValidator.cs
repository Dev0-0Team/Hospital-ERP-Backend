using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.PaymentMethods.Commands.CreatePaymentMethod
{
    public class CreatePaymentMethodValidator : AbstractValidator<CreatePaymentMethodRequest>
    {
        public CreatePaymentMethodValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Payment method name is required.")
                .MaximumLength(50).WithMessage("Payment method name must not exceed 50 characters.");
        }
    }
}
