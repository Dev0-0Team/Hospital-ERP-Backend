using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.InvoiceItems.Commands.DeleteInvoiceItem
{
    internal class DeleteInvoiceItemValidator
        : AbstractValidator<DeleteInvoiceItemRequest>
    {
        public DeleteInvoiceItemValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Invoice Item Id must be greater than 0.");
        }
    }
}