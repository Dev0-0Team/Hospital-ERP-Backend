using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Payments.Queries.GetPayment
{
    public class GetPaymentValidator : AbstractValidator<GetPaymentRequest>
    {
        public GetPaymentValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("ID must be greater than 0.");
        }
    }
}
