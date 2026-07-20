using FluentValidation;


namespace Hospital_ERP_Backend.Application.Features.PaymentMethods.Queries.GetPaymentMethod
{
    public class GetPaymentMethodValidator : AbstractValidator<GetPaymentMethodRequest>
    {
        public GetPaymentMethodValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Payment method Id must be greater than 0.");
        }
    }
}
