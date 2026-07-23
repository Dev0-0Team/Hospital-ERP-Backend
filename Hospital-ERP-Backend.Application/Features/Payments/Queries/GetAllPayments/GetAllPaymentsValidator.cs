using FluentValidation;


namespace Hospital_ERP_Backend.Application.Features.Payments.Queries.GetAllPayments
{
    public class GetAllPaymentsValidator : AbstractValidator<GetAllPaymentsRequest>
    {
        public GetAllPaymentsValidator()
        {
             RuleFor(x => x.Page)
                .GreaterThan(0).WithMessage("Page number must be greater than 0.");
        }
    }
}
