using FluentValidation;
using Hospital_ERP_Backend.Domain.Enums;

namespace Hospital_ERP_Backend.Application.Features.LabOrders.Commands.CreateLabOrder
{
    public class CreateLabOrderValidator : AbstractValidator<CreateLabOrderRequest>
    {
        public CreateLabOrderValidator()
        {
            RuleFor(x => x.PatientId)
                .GreaterThan(0).WithMessage("Patient ID must be greater than 0.");

            RuleFor(x => x.DoctorId)
                .GreaterThan(0).WithMessage("Doctor ID must be greater than 0.");

            RuleFor(x => x.Status)
                .Must(x => Enum.TryParse<LabOrderStatus>(x, true, out _))
                .WithMessage("Invalid lab order status, you must specify one of them: Completed, Sample_Collected, Cancelled, Ordered");
        }
    }
}