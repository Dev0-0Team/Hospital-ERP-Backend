using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.SurgeriesHistories.Queries.GetAllSurgeriesHistories
{
    internal class GetAllSurgeriesHistoriesValidator : AbstractValidator<GetAllSurgeriesHistoriesRequest>
    {
        public GetAllSurgeriesHistoriesValidator()
        {
            RuleFor(x => x.Page)
                .GreaterThan(0).WithMessage("Page number must be greater than 0.");
        }
    }
}