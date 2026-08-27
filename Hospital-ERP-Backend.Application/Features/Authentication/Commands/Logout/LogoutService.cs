using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Authentication.Commands.Logout;

internal sealed class LogoutService : IRequestHandler<LogoutRequest, bool>
{
    private readonly IRefreshTokenQueryRepository _query;

    private readonly IBaseCommandRepository<RefreshToken> _command;

    private readonly IValidator<LogoutRequest> _validator;

    public LogoutService(IRefreshTokenQueryRepository query, IBaseCommandRepository<RefreshToken> command, IValidator<LogoutRequest> validator)
    {
        _query = query;
        _command = command;
        _validator = validator;
    }


    public async Task<bool> Handle(LogoutRequest request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request);

        var tokens = await _query.GetActiveTokensByUserIdAsync(request.UserId);

        var storedToken = tokens.FirstOrDefault(x => BCrypt.Net.BCrypt.Verify(request.RefreshToken, x.TokenHash));

        if (storedToken is null)
        {
            throw new UnauthorizedAccessException("Invalid Refresh Token");
        }

        storedToken.RevokedAt = DateTime.UtcNow;

        await _command.UpdateAsync(storedToken);

        return true;
    }
}