using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.InvoiceItems.Queries.GetAllInvoiceItems
{
    internal class GetAllInvoiceItemsValidator : AbstractValidator<GetAllInvoiceItemsRequest>
    {
        public GetAllInvoiceItemsValidator()
        {
            RuleFor(x => x.Page)
                .GreaterThan(0)
                .WithMessage("Page number must be greater than 0.");
        }
    }
}