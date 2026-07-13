using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.LabOrders.Commands.DeleteLabOrder
{
    public class DeleteLabOrderValidator : AbstractValidator<DeleteLabOrderRequest>
    {
        public DeleteLabOrderValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Lab Order Id must be a positive integer.");
        }
    }
}