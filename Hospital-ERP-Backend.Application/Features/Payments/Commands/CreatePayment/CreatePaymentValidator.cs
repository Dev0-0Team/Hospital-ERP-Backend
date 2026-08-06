using FluentValidation;


namespace Hospital_ERP_Backend.Application.Features.Payments.Commands.CreatePayment
{
    internal class CreatePaymentValidator : AbstractValidator<CreatePaymentRequest>
    {
        public CreatePaymentValidator()
        {
            RuleFor(x => x.InvoiceId)
              .GreaterThan(0).WithMessage("Invoice ID must be greater than 0.");

            RuleFor(x => x.PaymentMethodId)
              .GreaterThan(0).WithMessage("Payment Method ID must be greater than 0.");

            RuleFor(x => x.Amount)
               .GreaterThan(0).WithMessage("Amount must be greater than 0.");
            
            RuleFor(x => x.PaidAt)
                .LessThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("Paid At cannot be in the future");
        }
    }
}
