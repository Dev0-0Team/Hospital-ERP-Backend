using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.AdministrativeStaffs.Queries.GetAllAdministrativeStaffs
{
    internal class GetAllAdministrativeStaffsValidator : AbstractValidator<GetAllAdministrativeStaffsRequest>
    {
        public GetAllAdministrativeStaffsValidator()
        {
            RuleFor(x => x.Page)
                .GreaterThan(0)
                .WithMessage("Page must be greater than 0.");
        }
    }
}