using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.MedicalRecords.Commands.DeleteMedicalRecord
{
    public class DeleteMedicalRecordValidator : AbstractValidator<DeleteMedicalRecordRequest>
    {
        public DeleteMedicalRecordValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("ID must be greater than 0.");
        }
    }
}