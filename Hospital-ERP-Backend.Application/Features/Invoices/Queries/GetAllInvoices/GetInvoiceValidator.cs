using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Invoices.Queries.GetAllInvoices
{
    public class GetAllInvoicesValidator : AbstractValidator<GetAllInvoicesRequest>
    {
        public GetAllInvoicesValidator()
        {
            RuleFor(x => x.Page)
                .GreaterThan(0).WithMessage("Page number must be greater than 0.");
        }
    }
}