using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.InvoiceItems.Queries.GetInvoiceItem
{
    public class GetInvoiceItemValidator : AbstractValidator<GetInvoiceItemRequest>
    {
        public GetInvoiceItemValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Invoice Item Id must be greater than 0.");
        }
    }
}