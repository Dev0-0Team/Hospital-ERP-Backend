using FluentValidation;


namespace Hospital_ERP_Backend.Application.Features.Payments.Commands.DeletePayment
{
    public class DeletePaymentValidator : AbstractValidator<DeletePaymentRequest>
    {
        public DeletePaymentValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("ID must be greater than 0.");
        }
    }
}
