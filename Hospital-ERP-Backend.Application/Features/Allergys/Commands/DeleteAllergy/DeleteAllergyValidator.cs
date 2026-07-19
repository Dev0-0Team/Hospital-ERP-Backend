using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Allergys.Commamds.DeleteAllergy
{
    public class DeleteAllergyValidator : AbstractValidator<DeleteAllergyRequest>
    {
        public DeleteAllergyValidator()
        {


            RuleFor(x => x.Id)
                .NotEmpty()

                .WithMessage("Patient ID is seruired");

        }
    }
}
