using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.AdministrativeStaffs.Commands.DeleteAdministrativeStaff
{
    internal class DeleteAdministrativeStaffValidator : AbstractValidator<DeleteAdministrativeStaffRequest>
    {
        public DeleteAdministrativeStaffValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Id must be greater than 0.");
        }
    }
}