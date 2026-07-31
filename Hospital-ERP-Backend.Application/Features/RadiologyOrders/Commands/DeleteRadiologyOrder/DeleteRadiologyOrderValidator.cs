using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.RadiologyOrders.Commands.DeleteRadiologyOrder
{
    internal class DeleteRadiologyOrderValidator
        : AbstractValidator<DeleteRadiologyOrderRequest>
    {
        public DeleteRadiologyOrderValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }
}