using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_ERP_Backend.Application.Features.Permissions.Queries.GetAllPermissionsOfUser
{
    public record GetAllPermissionsOfUserResponse
    {
        public string Group {get;set;} = null!;
        public ulong BitValue {get;set;}
    }
}