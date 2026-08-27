using FluentValidation;
using Hospital_ERP_Backend.Application.Security;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using Hospital_ERP_Backend.Domain.Interfaces.Permission;
using Hospital_ERP_Backend.Domain.Interfaces.User;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Authentication.Commands.RefreshTokens;

internal class RefreshTokenService
    : IRequestHandler<RefreshTokenRequest, RefreshTokenResponse>
{
    private readonly IRefreshTokenQueryRepository _refreshTokenQuery;

    private readonly IBaseCommandRepository<RefreshToken> _refreshTokenCommand;

    private readonly IUserQueryRepository _userRepository;

    private readonly IPermissionQueryRepository _permissionRepository;

    private readonly JwtTokenService _jwtTokenService;

    private readonly IValidator<RefreshTokenRequest> _validator;

    public RefreshTokenService(
        IRefreshTokenQueryRepository refreshTokenQuery,
        IBaseCommandRepository<RefreshToken> refreshTokenCommand,
        IUserQueryRepository userRepository,
        IPermissionQueryRepository permissionRepository,
        JwtTokenService jwtTokenService,
        IValidator<RefreshTokenRequest> validator)
    {
        _refreshTokenQuery = refreshTokenQuery;
        _refreshTokenCommand = refreshTokenCommand;
        _userRepository = userRepository;
        _permissionRepository = permissionRepository;
        _jwtTokenService = jwtTokenService;
        _validator = validator;
    }

    public async Task<RefreshTokenResponse> Handle(RefreshTokenRequest request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request);

        var hash = JwtTokenService.ComputeHash(request.RefreshToken);

        var storedToken = await _refreshTokenQuery.GetByHashAsync(hash);

        if (storedToken is null)
        {
            throw new UnauthorizedAccessException("Invalid Refresh Token");
        }

        if (storedToken.RevokedAt != null)
        {
            throw new UnauthorizedAccessException("Refresh Token Revoked");
        }

        if (storedToken.ExpiresAt < DateTime.UtcNow)
        {
            throw new UnauthorizedAccessException("Refresh Token Expired");
        }

        var user = await _userRepository.GetAsync(storedToken.UserId);

        if (user is null)
        {
            throw new UnauthorizedAccessException("User Not Found");
        }


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

        var accessToken = _jwtTokenService.GenerateToken(
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

        var newRefreshToken = JwtTokenService.GenerateRefreshToken();

        var newHash = JwtTokenService.ComputeHash(newRefreshToken);

        storedToken.RevokedAt = DateTime.UtcNow;

        await _refreshTokenCommand.UpdateAsync(storedToken);

        await _refreshTokenCommand.CreateAsync(
            new RefreshToken
            {
                UserId = user.Id,

                TokenHash = newHash,

                ExpiresAt = DateTime.UtcNow.AddDays(30),

                CreatedAt = DateTime.UtcNow
            });

        return new RefreshTokenResponse
        {
            AccessToken = accessToken.Token,

            RefreshToken = newRefreshToken,

            ExpireAt = accessToken.ExpireAt
        };
    }
}