using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.RoomAssignments.Commands.UpdateRoomAssignment
{
    public class UpdateRoomAssignmentValidator : AbstractValidator<UpdateRoomAssignmentRequest>
    {
        public UpdateRoomAssignmentValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");

            RuleFor(x => x.PatientId)
                .GreaterThan(0).WithMessage("Patient Id must be greater than 0.");

            RuleFor(x => x.BedId)
                .GreaterThan(0).WithMessage("Bed Id must be greater than 0.");

            RuleFor(x => x.AdmittedAt)
                .NotEmpty().WithMessage("Admitted date is required.");

            RuleFor(x => x.DischargedAt)
                .GreaterThan(x => x.AdmittedAt)
                .When(x => x.DischargedAt.HasValue)
                .WithMessage("Discharged date must be after the admitted date.");
        }
    }
}