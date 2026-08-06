using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.MedicalRecords.Queries.GetMedicalRecord
{
    internal class GetMedicalRecordValidator : AbstractValidator<GetMedicalRecordRequest>
    {
        public GetMedicalRecordValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("ID must be greater than 0.");
        }
    }
}