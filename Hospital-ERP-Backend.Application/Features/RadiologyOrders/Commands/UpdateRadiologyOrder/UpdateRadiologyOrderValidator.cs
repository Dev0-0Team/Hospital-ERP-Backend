using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.RadiologyOrders.Commands.UpdateRadiologyOrder
{
    public class UpdateRadiologyOrderValidator
        : AbstractValidator<UpdateRadiologyOrderRequest>
    {
        public UpdateRadiologyOrderValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");

            RuleFor(x => x.PatientId)
                .GreaterThan(0).WithMessage("Patient Id must be greater than 0.");

            RuleFor(x => x.DoctorId)
                 .GreaterThan(0).WithMessage("Doctor Id must be greater than 0.");

            RuleFor(x => x.Type)
               .NotEmpty().WithMessage("Radiology type must be not empty."); ;

            RuleFor(x => x.Status)
                .Must(x =>
                    x == "Ordered" ||
                    x == "Scheduled" ||
                    x == "Completed" ||
                    x == "Cancelled").WithMessage("Invalid status."); ;
        }
    }
}