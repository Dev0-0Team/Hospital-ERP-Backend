using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.InvoiceItems.Commands.CreateInvoiceItem
{
    public class CreateInvoiceItemValidator : AbstractValidator<CreateInvoiceItemRequest>
    {
        public CreateInvoiceItemValidator()
        {
            RuleFor(x => x.InvoiceId)
                .GreaterThan(0)
                .WithMessage("Invoice Id must be greater than 0.");

            RuleFor(x => x.ItemName)
                .NotEmpty()
                .MaximumLength(200)
                .WithMessage("Item Name is required.");

            RuleFor(x => x.Amount)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Amount must be greater than or equal to 0.");

            RuleFor(x => x.ReferenceId)
                .GreaterThan(0)
                .WithMessage("Reference Id must be greater than 0.");


            //Must be test
            RuleFor(x => x.ReferenceType)
                .IsInEnum()
                .WithMessage("Invalid Reference Type.");
        }
    }
}