using FluentValidation;


namespace Hospital_ERP_Backend.Application.Features.PaymentMethods.Queries.GetAllPaymentMethods
{
    internal class GetAllPaymentMethodsValidator : AbstractValidator<GetAllPaymentMethodsRequest>
    {
        public GetAllPaymentMethodsValidator()
        {
            RuleFor(x => x.Page)
                .GreaterThan(0).WithMessage("Page number must be greater than 0.");
        }
    }
}
