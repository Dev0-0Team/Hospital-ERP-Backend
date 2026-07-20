using FluentValidation;


namespace Hospital_ERP_Backend.Application.Features.PaymentMethods.Commands.DeletePaymentMethod
{
    public class DeletePaymentMethodValidator : AbstractValidator<DeletePaymentMethodRequest>
    {
        public DeletePaymentMethodValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Payment method Id must be greater than zero.");
        }
    }
}
