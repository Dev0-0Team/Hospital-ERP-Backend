using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_ERP_Backend.Application.Features.UserRoles.Queries.GetAllUserRoles
{
    public class GetAllUserRolesService
    {
        private readonly IValidator<GetAllUserRolesRequest> _validator;
        private readonly IBaseQueryRepository<UserRole> _iUserRole;

        public GetAllUserRolesService(IValidator<GetAllUserRolesRequest> validator, IBaseQueryRepository<UserRole> iUserRole)
        {
            _validator = validator;
            _iUserRole = iUserRole;
        }

        public async Task<IEnumerable<GetAllUserRolesResponse>> GetAllUserRolesAsync(GetAllUserRolesRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            var userRoles = await _iUserRole.GetAllAsync(request.Page);
            if (userRoles == null || userRoles.Count() == 0)
            {
                throw new KeyNotFoundException($"No user roles found on page {request.Page}.");
            }

            return userRoles.Select(ur => new GetAllUserRolesResponse
            {
                Id = ur.Id,
                UserId = ur.UserId,
                RoleId = ur.RoleId
            });
        }
    }
}
