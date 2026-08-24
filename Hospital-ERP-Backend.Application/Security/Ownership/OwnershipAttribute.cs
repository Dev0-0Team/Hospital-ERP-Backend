using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_ERP_Backend.Application.Security.Authorization;
public sealed class OwnershipAttribute : AuthorizeAttribute
{
    public OwnershipAttribute()
    {
        Policy = "Ownership";
    }
}






