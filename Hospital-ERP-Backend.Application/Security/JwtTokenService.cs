using Hospital_ERP_Backend.API.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Hospital_ERP_Backend.Application.Security;

public sealed class JwtTokenService
{
    private readonly JwtSettings _jwtSettings;

    public JwtTokenService(IOptions<JwtSettings> jwtOptions)
    {
        _jwtSettings = jwtOptions.Value;
    }

    public JwtTokenResponse GenerateToken(
        int userId,
        int personId,
        string email,

        ulong securityPermissions,
        ulong patientPermissions,
        ulong medicalPermissions,
        ulong appointmentPermissions,
        ulong emergencyPermissions,
        ulong staffPermissions,
        ulong laboratoryPermissions,
        ulong radiologyPermissions,
        ulong pharmacyPermissions,
        ulong billingPermissions,
        ulong hospitalPermissions,
        ulong notificationPermissions)
    {
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new("userId", userId.ToString()),
            new("personId", personId.ToString()),
            new(JwtRegisteredClaimNames.Email, email),

            new("security_permissions", securityPermissions.ToString()),
            new("patient_permissions", patientPermissions.ToString()),
            new("medical_permissions", medicalPermissions.ToString()),
            new("appointment_permissions", appointmentPermissions.ToString()),
            new("emergency_permissions", emergencyPermissions.ToString()),
            new("staff_permissions", staffPermissions.ToString()),
            new("laboratory_permissions", laboratoryPermissions.ToString()),
            new("radiology_permissions", radiologyPermissions.ToString()),
            new("pharmacy_permissions", pharmacyPermissions.ToString()),
            new("billing_permissions", billingPermissions.ToString()),
            new("hospital_permissions", hospitalPermissions.ToString()),
            new("notification_permissions", notificationPermissions.ToString())
        };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_jwtSettings.Key));

        var credentials =
            new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256);

        var expires =
            DateTime.UtcNow.AddMinutes(
                _jwtSettings.DurationInMinutes);

        var token =
            new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: expires,
                signingCredentials: credentials);

        return new JwtTokenResponse
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            ExpireAt = expires
        };
    }
}