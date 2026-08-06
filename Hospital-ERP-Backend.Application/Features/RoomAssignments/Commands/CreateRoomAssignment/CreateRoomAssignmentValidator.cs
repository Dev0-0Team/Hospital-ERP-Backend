using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.RoomAssignments.Commands.CreateRoomAssignment
{
    internal class CreateRoomAssignmentValidator : AbstractValidator<CreateRoomAssignmentRequest>
    {
        public CreateRoomAssignmentValidator()
        {
            RuleFor(x => x.PatientId)
                .GreaterThan(0).WithMessage("Patient Id must be greater than 0.");

            RuleFor(x => x.BedId)
                .GreaterThan(0).WithMessage("Bed Id must be greater than 0.");

            RuleFor(x => x.AdmittedAt)
                .NotEmpty()
                .LessThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("Admitted date cannot be in the future.");

            RuleFor(x => x.DischargedAt)
                .GreaterThan(x => x.AdmittedAt)
                .When(x => x.DischargedAt.HasValue)
                .WithMessage("Discharged date must be after the admitted date.");
        }
    }
}