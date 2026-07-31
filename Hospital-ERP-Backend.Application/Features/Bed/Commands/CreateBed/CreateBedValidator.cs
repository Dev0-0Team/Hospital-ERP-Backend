using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Beds.Commands.CreateBed
{
    internal class CreateBedValidator : AbstractValidator<CreateBedRequest>
    {
        public CreateBedValidator()
        {
            RuleFor(x => x.RoomId)
                .GreaterThan(0).WithMessage("Room Id must be greater than 0.");

            RuleFor(x => x.BedNumber)
                .NotEmpty().WithMessage("Bed number is required.")
                .MaximumLength(20).WithMessage("Bed number must not exceed 20 characters.");

            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("Status is required.")
                .Must(BeValidStatus).WithMessage("Status must be Available, Occupied, or Maintenance.");
        }

        private bool BeValidStatus(string Status)
        {
            var allowed = new[] { "Available", "Occupied", "Maintenance" };
            return allowed.Contains(Status);
        }
    }
}