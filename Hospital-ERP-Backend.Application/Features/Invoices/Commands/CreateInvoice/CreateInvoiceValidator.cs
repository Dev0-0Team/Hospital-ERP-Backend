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
                .Must(BeValidStatus)
                .WithMessage("Invalid invoice status.");
        }

        private bool BeValidStatus(string status)
        {
            return Enum.IsDefined(typeof(InvoiceStatus), status);
        }
    }
}
