using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.MedicalRecords.Queries.GetAllMedicalRecords
{
    public class GetAllMedicalRecordsValidator : AbstractValidator<GetAllMedicalRecordsRequest>
    {
        public GetAllMedicalRecordsValidator()
        {
            RuleFor(x => x.Page)
                .GreaterThan(0).WithMessage("Page must be greater than 0.");
        }
    }
}