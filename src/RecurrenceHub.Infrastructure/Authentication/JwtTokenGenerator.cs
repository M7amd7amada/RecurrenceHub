using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using RecurrenceHub.Application.Common.Interfaces.Authentication;
using RecurrenceHub.Application.Common.Interfaces.Services;

namespace RecurrenceHub.Infrastructure.Authentication;

public class JwtTokenGenerator(
    IDateTimeProvider dateTimeProvider,
    IOptions<JwtSettings> jwtSettingsOptions) : IJwtTokenGenerator
{
    private readonly JwtSettings _jwtSettings = jwtSettingsOptions.Value;

    public string GenerateToken(Guid userId, string firstName, string lastName)
    {
        var singingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
            SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>()
        {
            new (JwtRegisteredClaimNames.Sub, userId.ToString()),
            new (JwtRegisteredClaimNames.GivenName, firstName),
            new (JwtRegisteredClaimNames.FamilyName, lastName),
            new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var securityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: dateTimeProvider.UtcNow.AddDays(_jwtSettings.ExpiryMinutes),
            signingCredentials: singingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}
