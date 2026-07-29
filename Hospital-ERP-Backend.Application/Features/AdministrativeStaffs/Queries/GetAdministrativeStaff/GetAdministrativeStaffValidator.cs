using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.AdministrativeStaffs.Queries.GetAdministrativeStaff
{
    internal class GetAdministrativeStaffValidator : AbstractValidator<GetAdministrativeStaffRequest>
    {
        public GetAdministrativeStaffValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Id must be greater than 0.");
        }
    }
}