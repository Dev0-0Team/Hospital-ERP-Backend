using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Doctors.Commands.DeleteDoctor
{
    internal class DeleteDoctorValidator : AbstractValidator<DeleteDoctorRequest>
    {
        public DeleteDoctorValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Id must be greater than 0.");
        }
    }
}