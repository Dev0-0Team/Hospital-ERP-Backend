using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_ERP_Backend.Application.Features.Nurses.Commands.DeleteNurse
{
    public class DeleteNurseValidator : AbstractValidator<DeleteNurseRequest>
    {
        public DeleteNurseValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("ID must be greater than 0.");
        }
    }
}
