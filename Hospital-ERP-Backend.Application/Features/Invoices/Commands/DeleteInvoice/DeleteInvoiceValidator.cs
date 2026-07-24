using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Invoices.Commands.DeleteInvoice
{
    public class DeleteInvoiceValidator : AbstractValidator<DeleteInvoiceRequest>
    {
        public DeleteInvoiceValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Invoice Id must be greater than 0.");
        }
    }
}