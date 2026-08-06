using FluentValidation;
using Hospital_ERP_Backend.Domain.Enums;


namespace Hospital_ERP_Backend.Application.Features.Invoices.Commands.UpdateInvoice
{
    internal class UpdateInvoiceValidator : AbstractValidator<UpdateInvoiceRequest>
    {
        public UpdateInvoiceValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");

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
