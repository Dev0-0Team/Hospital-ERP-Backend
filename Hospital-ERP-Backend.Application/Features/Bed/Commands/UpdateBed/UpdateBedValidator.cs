using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Beds.Commands.UpdateBed
{
    internal class UpdateBedValidator : AbstractValidator<UpdateBedRequest>
    {
        public UpdateBedValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");

            RuleFor(x => x.RoomId)
                .GreaterThan(0).WithMessage("Room Id must be greater than 0.");

            RuleFor(x => x.BedNumber)
                .NotEmpty().WithMessage("Bed number is required.")
                .MaximumLength(20).WithMessage("Bed number must not exceed 20 characters.");

            RuleFor(x => x.Status)
            .IsInEnum().WithMessage("Status must be Available, Occupied, or Maintenance.");
        }
    }
}
