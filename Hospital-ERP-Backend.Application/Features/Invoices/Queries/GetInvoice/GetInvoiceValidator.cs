using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Invoices.Queries.GetInvoice
{
    public class GetInvoiceValidator : AbstractValidator<GetInvoiceRequest>
    {
        public GetInvoiceValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Invoice Id must be greater than 0.");
        }
    }
}