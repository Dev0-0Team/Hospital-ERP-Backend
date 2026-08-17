using Hospital_ERP_Backend.Application.Security;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Permission;
using Hospital_ERP_Backend.Domain.Interfaces.User;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Hospital_ERP_Backend.Application.Features.Authentication.Commands.Login;

public sealed class LoginService : IRequestHandler<LoginRequest, LoginResponse>
{
    private readonly IUserQueryRepository _userRepository;
    private readonly JwtTokenService _jwtTokenService;
    private readonly IPermissionQueryRepository _permissionRepository;

    public LoginService(IUserQueryRepository userRepository, JwtTokenService jwtTokenService, IPermissionQueryRepository permissionRepository)
    {
        _userRepository = userRepository;
        _jwtTokenService = jwtTokenService;
        _permissionRepository = permissionRepository;
    }

    public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        return await ExecuteAsync(request);
    }

    private async Task<LoginResponse> ExecuteAsync(LoginRequest request)
    {
        var user = await _userRepository.GetUserByEmailAsync(request.Email);

        if (user is null)
        {
            throw new UnauthorizedAccessException("Invalid Email or Password");
        }

        var passwordHasher = new PasswordHasher<User>();

        var result = passwordHasher.VerifyHashedPassword(
                user,
                user.PasswordHash,
                request.Password);

        if (result == PasswordVerificationResult.Failed)
        {
            throw new UnauthorizedAccessException("Invalid Email or Password");

        }

        var permissions = await _permissionRepository.GetUserPermissionBitValuesAsync(user.Id);

        //Permission Masks 
        ulong securityPermissions = 0;
        ulong patientPermissions = 0;
        ulong medicalPermissions = 0;
        ulong appointmentPermissions = 0;
        ulong staffPermissions = 0;
        ulong laboratoryPermissions = 0;
        ulong radiologyPermissions = 0;
        ulong pharmacyPermissions = 0;
        ulong billingPermissions = 0;
        ulong hospitalPermissions = 0;
        ulong notificationPermissions = 0;

        foreach (var permission in permissions)
        {
            switch (permission.Group)
            {
                case "Security":
                    securityPermissions |= permission.BitValue;
                    break;
                case "Patients":
                    patientPermissions |= permission.BitValue;
                    break;
                case "Medical":
                    medicalPermissions |= permission.BitValue;
                    break;
                case "Appointments":
                    appointmentPermissions |= permission.BitValue;
                    break;
                case "Emergency":
                    emergencyPermissions |= permission.BitValue;
                    break;
                case "Staff":
                    staffPermissions |= permission.BitValue;
                    break;
                case "Laboratory":
                    laboratoryPermissions |= permission.BitValue;
                    break;
                case "Radiology":
                    radiologyPermissions |= permission.BitValue;
                    break;
                case "Pharmacy":
                    pharmacyPermissions |= permission.BitValue;
                    break;
                case "Billing":
                    billingPermissions |= permission.BitValue;
                    break;
                case "Facility":
                    hospitalPermissions |= permission.BitValue;
                    break;
                case "Notification":
                    notificationPermissions |= permission.BitValue;
                    break;
            }
        }


        var token = _jwtTokenService.GenerateToken(
                user.Id,
                user.PersonId,

                securityPermissions,
                patientPermissions,
                medicalPermissions,
                appointmentPermissions,
                staffPermissions,
                laboratoryPermissions,
                radiologyPermissions,
                pharmacyPermissions,
                billingPermissions,
                hospitalPermissions,
                notificationPermissions);

        return new LoginResponse
        {
            Token = token.Token,
            ExpireAt = token.ExpireAt,
            UserId = user.Id,
            PersonId = user.PersonId,
        };
    }
}