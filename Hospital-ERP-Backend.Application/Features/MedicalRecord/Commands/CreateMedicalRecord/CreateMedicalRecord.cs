using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.MedicalRecords.Commands.CreateMedicalRecord
{
    public class CreateMedicalRecordValidator : AbstractValidator<CreateMedicalRecordRequest>
    {
        public CreateMedicalRecordValidator()
        {
            RuleFor(x => x.PatientId)
                .GreaterThan(0).WithMessage("Patient ID must be greater than 0.");

            RuleFor(x => x.DoctorId)
                .GreaterThan(0).WithMessage("Doctor ID must be greater than 0.");

            RuleFor(x => x.Diagnosis)
                .NotEmpty().WithMessage("Diagnosis is required.")
                .MaximumLength(500).WithMessage("Diagnosis must not exceed 500 characters.");

            RuleFor(x => x.Notes)
                .MaximumLength(1000).WithMessage("Notes must not exceed 1000 characters.")
                .When(x => !string.IsNullOrWhiteSpace(x.Notes));

            RuleFor(x => x.VisitDate)
                .NotEmpty().WithMessage("Visit date is required.");
        }
    }
}