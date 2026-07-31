using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Beds.Commands.DeleteBed
{
    internal class DeleteBedValidator : AbstractValidator<DeleteBedRequest>
    {
        public DeleteBedValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }
}