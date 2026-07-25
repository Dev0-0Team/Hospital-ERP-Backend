using FluentValidation;
using Hospital_ERP_Backend.Domain.Enums;


namespace Hospital_ERP_Backend.Application.Features.Invoices.Commands.CreateInvoice
{
    public class CreateInvoiceValidator : AbstractValidator<CreateInvoiceRequest>
    {
        public CreateInvoiceValidator()
        {
            RuleFor(x => x.PatientId)
               .GreaterThan(0).WithMessage("Patient id must be greater than 0");

            RuleFor(x => x.TotalAmount)
               .GreaterThan(0).WithMessage("Total amount must be greater than 0");

            RuleFor(x => x.Status)
                .Must(x => Enum.IsDefined(typeof(InvoiceStatus), x))
                .WithMessage("Invalid invoice status.");
        }
    }
}
