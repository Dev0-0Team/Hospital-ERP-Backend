using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Doctors.Commands.DeleteDoctor
{
    public class DeleteDoctorValidator : AbstractValidator<DeleteDoctorRequest>
    {
        public DeleteDoctorValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0);
        }
    }
}