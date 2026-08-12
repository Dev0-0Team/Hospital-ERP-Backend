

using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.SurgeriesHistories.Commands.DeleteSurgeriesHistory
{
    internal class DeleteSurgeriesHistoryValidator : AbstractValidator<DeleteSurgeriesHistoryRequest>
    {
        public DeleteSurgeriesHistoryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0)
                .WithMessage("Id must be greater than 0.");
        }
    }
}