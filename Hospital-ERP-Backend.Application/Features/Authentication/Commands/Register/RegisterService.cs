using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.User;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Hospital_ERP_Backend.Application.Features.Authentication.Commands.Register;

public class RegisterService : IRequestHandler<RegisterRequest, RegisterResponse>
{
    private readonly IUserQueryRepository _user;
    private readonly IUserCommandRepository _userCommand;
    public RegisterService(IUserQueryRepository user, IUserCommandRepository userCommand)
    {
        _user = user;
        _userCommand = userCommand;
    }

    public async Task<RegisterResponse> Handle(RegisterRequest request, CancellationToken cancellationToken)
    {
        return await ExecuteAsync(request);
    }

    public async Task<RegisterResponse> ExecuteAsync(RegisterRequest request)
    {
        var emailExists = await _user.IsEmailExistsAsync(request.Email);

        if (emailExists)
        {
            throw new InvalidOperationException("A user with this email already exists.");
        }

        var person = new Person
        {
            FullName = request.FullName,
            Dob = request.Dob,
            Gender = request.Gender,
            Phone = request.Phone,
            Address = request.Address,

            CreatedAt = DateTime.UtcNow,
            IsDeleted = false
        };

        var passwordHasher = new PasswordHasher<User>();

        var user = new User
        {
            Person = person,
            Email = request.Email,
            Status = "Active",

            CreatedAt = DateTime.UtcNow,
            IsDeleted = false
        };

        user.PasswordHash = passwordHasher.HashPassword(user, request.Password);

        await _userCommand.CreateAsync(user);

        return new RegisterResponse
        {
            UserId = user.Id,
            PersonId = person.Id,
            Email = user.Email,
            Message = "User registered successfully."
        };
    }

}