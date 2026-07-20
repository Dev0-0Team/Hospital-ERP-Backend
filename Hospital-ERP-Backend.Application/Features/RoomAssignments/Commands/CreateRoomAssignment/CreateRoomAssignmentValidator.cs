using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.RoomAssignments.Commands.CreateRoomAssignment
{
    public class CreateRoomAssignmentValidator : AbstractValidator<CreateRoomAssignmentRequest>
    {
        public CreateRoomAssignmentValidator()
        {
            RuleFor(x => x.PatientId)
                .GreaterThan(0).WithMessage("Patient Id must be greater than 0.");

            RuleFor(x => x.BedId)
                .GreaterThan(0).WithMessage("Bed Id must be greater than 0.");

            RuleFor(x => x.DischargedAt)
                .GreaterThan(x => x.AdmittedAt)
                .When(x => x.DischargedAt.HasValue && x.AdmittedAt.HasValue)
                .WithMessage("Discharged date must be after the admitted date.");
        }
    }
}